using Spectre.Console;

namespace Helper
{
    public static class SpectreConsoleHelper
    {
        public static void Print(List<string> headersText, IEnumerable<IEnumerable<string>> content)
        {
            Grid grid = CreateAGridWithHeaders(headersText.Count, headersText);

            foreach (var item in content)
            {
                AddRowsToGrid(grid, item.ToList());
            }

            AnsiConsole.Write(grid);
        }


        public static Grid CreateAGridWithHeaders(int numberOfColumns, List<string> headersText, List<Style> stylesToApply = null)
        {
            var grid = new Grid();

            stylesToApply ??=
                    [
                        new Style(Color.Blue, null, Decoration.Bold),
                        new Style(Color.White, null, Decoration.Bold),
                        new Style(Color.Red, null, Decoration.Bold),
                    ];

            for (int i=0; i < numberOfColumns; i++)
                grid.AddColumn();

            Text[] styledHeaders = new Text[numberOfColumns];

            for (int i=0;i < numberOfColumns; i++)
            {
                Text styledHeader;

                if (stylesToApply != null)
                    styledHeader = new Text(headersText[i], stylesToApply[i]);
                else
                    styledHeader = new Text(headersText[i]);

                styledHeaders[i] = styledHeader;
            }

            grid.AddRow(styledHeaders);

            return grid;
        }

        public static Grid AddRowsToGrid(Grid grid, List<string> content, List<Style> stylesToApply = null)
        {
            int numberOfCols = grid.Columns.Count;
            Text[] row = new Text[numberOfCols];

            stylesToApply ??=
                    [
                        new Style(Color.Blue, null, Decoration.Bold),
                        new Style(Color.White, null, Decoration.Bold),
                        new Style(Color.Red, null, Decoration.Bold),
                    ];

            for (int i = 0; i < content.Count; i++)
            {
                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = new Text(content[i].ToString(), stylesToApply[j]);
                }
                grid.AddRow(row);
            }

            return grid;
        }

        public static Rule CreateSeparatorRule(string title, string titleColor = "red", string justify = "left", string lineColor = "")
        {
            if (string.IsNullOrEmpty(title))
                return new Rule();

            string coloredTitle = $"[{titleColor}]{title}[/]";
            var rule = new Rule(coloredTitle);

            switch (justify)
            {
                case "left":
                    rule.LeftJustified();
                    break;
                case "right":
                    rule.RightJustified();
                    break;
                case "center":
                    break;
                default:
                    rule.LeftJustified();
                    break;
            }
            if (!string.IsNullOrEmpty(lineColor))
                rule.Style = lineColor;

            return rule;
        }

        public static Panel CreateResultPanel(string header, string content, Padding? paddding = null, bool expand = false, BoxBorder? border = null)
        {
            border ??= BoxBorder.Square;

            var panel = new Panel(content)
            {
                Header = new PanelHeader(header),
                Padding = paddding,
                Expand = expand,
                Border = border
            };

            return panel;
        }
    }
}
