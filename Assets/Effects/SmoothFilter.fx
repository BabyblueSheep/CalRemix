sampler uImage0 : register(s0);
float2 uScreenResolution;

float4 PixelShaderFunction(float4 baseColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
	float2 uv = coords;
	//uv -= fmod(coords, float2(1.0, 1.0) / uScreenResolution.xy);
	
	uv.x -= uv.x % (1 / (uScreenResolution.x * 2));
    uv.y -= uv.y % (1 / (uScreenResolution.y * 2));

	float mx = 1.0;
	const float k = -1.10;
	const float max_w = 0.75;
	const float min_w = 0.03;
	const float lum_add = 0.33;

	float4 color = tex2D(uImage0, uv);
	float3 c = color.xyz;

	float z = 1;
	float x = z / uScreenResolution.x;
	float y = z / uScreenResolution.y;

	const float3 dt = float3(1.0, 1.0, 1.0);

	float2 dg1 = float2( x, y);
	float2 dg2 = float2(-x, y);

	float2 sd1 = dg1*0.5;
	float2 sd2 = dg2*0.5;

	float2 ddx = float2(x,0.0);
	float2 ddy = float2(0.0,y);

	float4 t1 = float4(uv-sd1,uv-ddy);
	float4 t2 = float4(uv-sd2,uv+ddx);
	float4 t3 = float4(uv+sd1,uv+ddy);
	float4 t4 = float4(uv+sd2,uv-ddx);
	float4 t5 = float4(uv-dg1,uv-dg2);
	float4 t6 = float4(uv+dg1,uv+dg2);

	float3 i1 = tex2D(uImage0, t1.xy).xyz;
	float3 i2 = tex2D(uImage0, t2.xy).xyz;
	float3 i3 = tex2D(uImage0, t3.xy).xyz;
	float3 i4 = tex2D(uImage0, t4.xy).xyz;

	float3 o1 = tex2D(uImage0, t5.xy).xyz;
	float3 o3 = tex2D(uImage0, t6.xy).xyz;
	float3 o2 = tex2D(uImage0, t5.zw).xyz;
	float3 o4 = tex2D(uImage0, t6.zw).xyz;

	float3 s1 = tex2D(uImage0, t1.zw).xyz;
	float3 s2 = tex2D(uImage0, t2.zw).xyz;
	float3 s3 = tex2D(uImage0, t3.zw).xyz;
	float3 s4 = tex2D(uImage0, t4.zw).xyz;

	float ko1 = dot(abs(o1-c),dt);
	float ko2 = dot(abs(o2-c),dt);
	float ko3 = dot(abs(o3-c),dt);
	float ko4 = dot(abs(o4-c),dt);

	float k1=min(dot(abs(i1-i3),dt),max(ko1,ko3));
	float k2=min(dot(abs(i2-i4),dt),max(ko2,ko4));

	float w1 = k2; if(ko3<ko1) w1*=ko3/ko1;
	float w2 = k1; if(ko4<ko2) w2*=ko4/ko2;
	float w3 = k2; if(ko1<ko3) w3*=ko1/ko3;
	float w4 = k1; if(ko2<ko4) w4*=ko2/ko4;

	c=(w1*o1+w2*o2+w3*o3+w4*o4+0.001*c)/(w1+w2+w3+w4+0.001);
	w1 = k*dot(abs(i1-c)+abs(i3-c),dt)/(0.125*dot(i1+i3,dt)+lum_add);
	w2 = k*dot(abs(i2-c)+abs(i4-c),dt)/(0.125*dot(i2+i4,dt)+lum_add);
	w3 = k*dot(abs(s1-c)+abs(s3-c),dt)/(0.125*dot(s1+s3,dt)+lum_add);
	w4 = k*dot(abs(s2-c)+abs(s4-c),dt)/(0.125*dot(s2+s4,dt)+lum_add);

	w1 = clamp(w1+mx,min_w,max_w);
	w2 = clamp(w2+mx,min_w,max_w);
	w3 = clamp(w3+mx,min_w,max_w);
	w4 = clamp(w4+mx,min_w,max_w);

	color = float4((w1*(i1+i3)+w2*(i2+i4)+w3*(s1+s3)+w4*(s2+s4)+c)/(2.0*(w1+w2+w3+w4)+1.0), 1.0);
	return color;
}

technique Technique1
{
    pass SmootheningPass
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}