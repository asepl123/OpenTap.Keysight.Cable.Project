using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Keysight.Cable.Project.Other
{
    public static class DataToFile
    {
        public static void Data2Csv(DataTable dt, string filename)
        {
            StringBuilder sb = new StringBuilder();

            string[] columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filename, sb.ToString());
        }

        public static void Data2Html(DataTable dt, string filename)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<!DOCTYPE html>");

            strHTMLBuilder.Append("<html lang=\"en\">");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("<meta charset = \"utf-8\">");
            strHTMLBuilder.Append("<title > Creating Fixed Header and Footer with CSS </title>");

            #region JAVASCRIPT

            /* Javascript */
            strHTMLBuilder.AppendLine("<script type = \"text/javascript\">");
            strHTMLBuilder.AppendLine("window.onload = () => {");
            strHTMLBuilder.AppendLine("divElement = document.querySelector(\".grid\");");
            strHTMLBuilder.AppendLine("elemHeight = divElement.offsetHeight;");
            strHTMLBuilder.AppendLine("document.querySelector(\".myTable\").style.marginTop = elemHeight + 'px';");
            strHTMLBuilder.AppendLine("};");
            strHTMLBuilder.AppendLine("</script>");

            #endregion JAVASCRIPT

            strHTMLBuilder.Append("</head>");

            strHTMLBuilder.Append("<body style = \"margin: 0; width: 100%;\">");

            #region CSS

            /* CSS */
            strHTMLBuilder.AppendLine("<style>");

            strHTMLBuilder.AppendLine(".grid { position:fixed; top:0; display:grid; margin:0; width:100 %; grid-template-columns:1fr 8fr 1fr; grid-template-rows:auto; background-color:white; z-index:1000; }.grid__name { text-align:center; } .grid__name p:first-of-type { font-size:40pt; margin-top:20px; } .grid__name p:nth-of-type(2) { font-size:30pt; margin-top:-20px; margin-bottom:10px; color:#800; }  table { position:absolute; margin:auto; border:1px solid #000; padding-top:37px; background:#500; width:fit-content; border-spacing:0; width:100%; } td + td { border-left:1px solid #eee; } td, th { border-bottom:1px solid #eee; background:#ddd; color:#000; padding:10px 25px; } th { height:0; line-height:0; padding-top:0; padding-bottom:0; color:transparent; border:none; white-space:nowrap; } th div{ position:absolute; background:transparent; color:#fff; padding:9px 25px; top:0; margin-left:-25px; line-height:normal; border-left:1px solid #800; } th:first-child div{ border:none; }");

            strHTMLBuilder.AppendLine("</style>");

            #endregion CSS

            strHTMLBuilder.Append("< div class=\"grid\">");
            strHTMLBuilder.Append("<div><img src = \"img/sac-logo-200-200-px.png\" alt=\"SAC Logo\" width=\"100%\"></div>");
            strHTMLBuilder.Append("<div class=\"grid__name\">");
            strHTMLBuilder.Append("<p>Cable Testing Solution</p>");
            strHTMLBuilder.Append("<p>Marker Data Table</p>");
            strHTMLBuilder.Append("</div>");
            strHTMLBuilder.Append("<div><img src = \"img/asepl-logo.png\" alt=\"ASEPL Logo\" width=\"100%\"></div>");
            strHTMLBuilder.Append("</div>");

            strHTMLBuilder.Append("<div>");
            strHTMLBuilder.Append("<table class=\"myTable\">");
            strHTMLBuilder.Append("<thead>");

            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<th>");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("<div>");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</div>");
                strHTMLBuilder.Append("</th>");
            }
            strHTMLBuilder.Append("</tr>");
            strHTMLBuilder.Append("</thead>");


            strHTMLBuilder.Append("<tbody>");

            foreach (DataRow myRow in dt.Rows)
            {

                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            strHTMLBuilder.Append("</tbody>");
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</div>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            File.WriteAllText(filename, strHTMLBuilder.ToString());
        }
    }
}
