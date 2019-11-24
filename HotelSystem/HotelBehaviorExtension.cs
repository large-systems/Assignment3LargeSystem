using System;
using System.ServiceModel.Configuration;

namespace HotelSystem
{
    public class HotelBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(HotelServiceBehavior);

        protected override object CreateBehavior()
        {
            return new HotelServiceBehavior();
        }
    }
}