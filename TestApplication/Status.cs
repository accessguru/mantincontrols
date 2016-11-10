using Mantin.Controls.Wpf.EnumComboBox;

namespace DemoApplication
{
    public enum Status
    {
        [StringValue("-- Select --")]
        None = 0,

        Active = 1,

        Inactive = 2,

        [StringValue("Pending Authorization")]
        PendingAuthorization = 3
    }
}
