using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang_pack_en
{
    public class LangEn
    {
        public List<Language> Langs;
        public LangEn()
        {
            Langs = new List<Language>();
            Langs.Add(new Language("_lang_title", "Main window"));
            Langs.Add(new Language("_lang_university_filter", "University filter"));
            Langs.Add(new Language("_lang_student_filter", "Student filter"));
            Langs.Add(new Language("_lang_create", "Create"));
            Langs.Add(new Language("_lang_edit", "Edit"));
            Langs.Add(new Language("_lang_remove", "Remove"));
        }
    }
}
