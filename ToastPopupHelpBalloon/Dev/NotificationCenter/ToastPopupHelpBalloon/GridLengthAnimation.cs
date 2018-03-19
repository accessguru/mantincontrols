using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace Mantin.Controls.Wpf.Notification
{
    public class GridLengthAnimation : AnimationTimeline
    {
        /// <summary>
        /// Returns the type of object to animate
        /// </summary>
        public override Type TargetPropertyType
        {
            get { return typeof (GridLength); }
        }

        /// <summary>
        /// Creates an instance of the animation object
        /// </summary>
        /// <returns>Returns the instance of the GridLengthAnimation</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAnimation();
        }

        /// <summary>
        /// Dependency property for the From property
        /// </summary>
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof (GridLength),
            typeof (GridLengthAnimation));

        /// <summary>
        /// CLR Wrapper for the From dependency property
        /// </summary>
        public GridLength From
        {
            get { return (GridLength) GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        /// <summary>
        /// Dependency property for the To property
        /// </summary>
        public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof (GridLength),
            typeof (GridLengthAnimation));

        /// <summary>
        /// CLR Wrapper for the To property
        /// </summary>
        public GridLength To
        {
            get { return (GridLength) GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        /// <summary>
        /// Animates the grid let set
        /// </summary>
        /// <param name="defaultOriginValue">The original value to animate</param>
        /// <param name="defaultDestinationValue">The final value</param>
        /// <param name="animationClock">The animation clock (timer)</param>
        /// <returns>Returns the new grid length to set</returns>
        public override object GetCurrentValue(object defaultOriginValue,
            object defaultDestinationValue, AnimationClock animationClock)
        {
            double fromVal = ((GridLength) GetValue(FromProperty)).Value;

            //check that from was set from the caller
            if (fromVal == 1)
            {
                //set the from as the actual value
                fromVal = ((GridLength) defaultDestinationValue).Value;
            }

            double toVal = ((GridLength) GetValue(ToProperty)).Value;

            if (fromVal > toVal)
            {
                return new GridLength((1 - animationClock.CurrentProgress.Value)*(fromVal - toVal) + toVal, GridUnitType.Star);
            }

            return new GridLength(animationClock.CurrentProgress.Value*(toVal - fromVal) + fromVal, GridUnitType.Star);
        }
    }
}
