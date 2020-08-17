using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookRental.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }

        public string Action { get; set; }

        public string Glyph { get; set; }

        public string Text { get; set; }
        
        public int? GenreId { get; set; }


        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");

                if (GenreId != null && GenreId > 0)
                {
                    param.Append(String.Format("{0}", GenreId));
                }

                return param.ToString();
            }
        }
    }
}