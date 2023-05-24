using System.Net.Mail;

namespace SR.Propertynator.Model;

public sealed class Global : IWritable
{
    public const string Name = "global";

    public BuildVersion      VersionBinary          { get; } = new BuildVersion();
    public BuildVersion      VersionBinaryDeveloper { get; } = new BuildVersion();
    public List<MailAddress> Recipients             { get; } = new List<MailAddress>();

    public void Write(TextWriter stream)
    {
        throw new NotImplementedException();
    }

    static private bool TryGetOnlyValidCellPropertyInUppercase(IList<string> cellProperties, out string cellPropertyUpperCase)
    {
        if (cellProperties.Count == 1)
        {
            cellPropertyUpperCase = cellProperties[0].ToUpper();

            switch (cellPropertyUpperCase)
            {
                case "Value":
                case "Note":
                case "NoteReporting":
                    return true;
            }
        }

        cellPropertyUpperCase = string.Empty;
        return false;
    }
}