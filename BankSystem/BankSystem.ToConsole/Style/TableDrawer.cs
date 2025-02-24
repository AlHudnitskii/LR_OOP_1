namespace OOP_LR1.BankSystem.ToConsole.Style
{
    public static class TableDrawer
    {
        public static void DrawTable(string[] headers, List<string[]> rows)
        {
            int[] columnWidths = headers.Select((header, index) =>
                Math.Max(header.Length, rows.Max(row => row[index].Length)))
                .ToArray();

            DrawLine(columnWidths, "┌", "┬", "┐");

            DrawRow(headers, columnWidths);

            DrawLine(columnWidths, "├", "┼", "┤");

            foreach (var row in rows)
            {
                DrawRow(row, columnWidths);
            }

            DrawLine(columnWidths, "└", "┴", "┘");
        }

        private static void DrawRow(string[] row, int[] columnWidths)
        {
            Console.Write("│");
            for (int i = 0; i < row.Length; i++)
            {
                Console.Write($" {row[i].PadRight(columnWidths[i])} │");
            }
            Console.WriteLine();
        }

        private static void DrawLine(int[] columnWidths, string left, string middle, string right)
        {
            Console.Write(left);
            for (int i = 0; i < columnWidths.Length; i++)
            {
                Console.Write(new string('─', columnWidths[i] + 2));
                if (i < columnWidths.Length - 1)
                {
                    Console.Write(middle);
                }
            }
            Console.WriteLine(right);
        }
    }
}
