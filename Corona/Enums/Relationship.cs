using System.ComponentModel;

namespace Corona.Enums
{
    public enum Relationship
    {
        [Description("Guardian")]
        Guardian = 1,

        [Description("Father")]
        Father,

        [Description("Mother")]
        Mother,

        [Description("Brother")]
        Brother,

        [Description("Sister")]
        Sister,

        [Description("Cousin")]
        Cousin,

        [Description("Foster Parent")]
        FosterParent
    }
}

