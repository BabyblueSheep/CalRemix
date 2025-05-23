﻿using CalRemix.UI;
using System;
using System.Collections.Generic;

namespace CalRemix.Core.OutboundCompatibility
{
    // By default dialog will only play once.
    public class MakeFannyDialogRepeatable : ModCallProvider<object>
    {
        public override IEnumerable<string> CallCommands
        {
            get
            {
                yield return "MakeFannyDialogRepeatable";
            }
        }

        public override string Name => "MakeFannyDialogRepeatable";

        public override IEnumerable<Type> InputTypes
        {
            get
            {
                yield return typeof(HelperMessage); // The dialog instance. This accepts the boxed object variant from CreateFannyDialog.
            }
        }

        protected override object ProcessGeneric(params object[] args)
        {
            HelperMessage message = (HelperMessage)args[0];
            message.OnlyPlayOnce = false;

            return message;
        }
    }
}
