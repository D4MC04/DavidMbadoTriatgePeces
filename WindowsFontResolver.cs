using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Fonts; // Obligatori per a la interfície
using PdfSharp;       // Obligatori per a GlobalFontSettings

namespace TriatgePeces
{
    public class WindowsFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            // Ruta estàndard de fonts a Windows
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), faceName);
            if (File.Exists(fontPath)) return File.ReadAllBytes(fontPath);

            // Font per defecte si no troba l'específica
            return File.ReadAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf"));
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string name = familyName.ToLower();
            if (familyName.Equals("Arial", StringComparison.OrdinalIgnoreCase))
            {
                if (isBold && isItalic) return new FontResolverInfo("arialbi.ttf");
                if (isBold) return new FontResolverInfo("arialbd.ttf");
                if (isItalic) return new FontResolverInfo("ariali.ttf");
                return new FontResolverInfo("arial.ttf");
            }
            return null;
        }
    }
}
