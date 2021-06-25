namespace MystPaste.NET
{
    public enum EditType
    {
        /// <summary>The paste's title was edited.</summary>
        PasteTitleEdited = 0,

        /// <summary>A pasty's title was edited.</summary>
        PastyTitleEdited = 1,

        /// <summary>A pasty's language was updated.</summary>
        PastyLanguageUpdated = 2,

        /// <summary>A pasty's code content was updated.</summary>
        PastyContentUpdated = 3,

        /// <summary>A pasty was added into the paste.</summary>
        PastyAdded = 4,

        /// <summary>A pasty was removed from the paste.</summary>
        PastyRemoved = 5
    }
}