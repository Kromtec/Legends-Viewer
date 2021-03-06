﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using LegendsViewer.Controls.Map;
using LegendsViewer.Legends;
using LegendsViewer.Legends.WorldObjects;

namespace LegendsViewer.Controls.HTML
{
    public class RiverPrinter : HtmlPrinter
    {
        River _river;
        World _world;

        public RiverPrinter(River river, World world)
        {
            _river = river;
            _world = world;
        }

        public override string GetTitle()
        {
            return _river.Name;
        }

        public override string Print()
        {
            Html = new StringBuilder();

            Html.AppendLine("<h1>" + _river.GetIcon() + " " + _river.Name + ", River</h1><br />");

            if (_river.Coordinates.Any())
            {
                List<Bitmap> maps = MapPanel.CreateBitmaps(_world, _river);

                Html.AppendLine("<table>");
                Html.AppendLine("<tr>");
                Html.AppendLine("<td>" + MakeLink(BitmapToHtml(maps[0]), LinkOption.LoadMap) + "</td>");
                Html.AppendLine("<td>" + MakeLink(BitmapToHtml(maps[1]), LinkOption.LoadMap) + "</td>");
                Html.AppendLine("</tr></table></br>");
            }

            PrintEventLog(_world, _river.Events, River.Filters, _river);

            return Html.ToString();
        }
    }
}
