using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SpreadsheetProjekt.Models
{
    //Az osztály legyen az absztrakt osztály leszármazottja és implementálja a megadott interfészeket!
    public class Spreadsheet : SpreadsheetBase, ITableManipulator
    {
        public Spreadsheet(int numberOfRows, int numberOfColumns) : base(numberOfRows, numberOfColumns) { }
        public Spreadsheet() : base(){ }
            
    
        public double AverageColumn(int columnIndex)
        {
            List<int> szamok = new List<int>();

            for (int row = 0; row < RowCount; row++)
            {
                if ( GetType(row, columnIndex) == CellType.Number)
                {
                    szamok.Add(Convert.ToInt32(this[row, columnIndex]));
                }
            }

            return szamok.Average();
        }

        public double AverageRow(int rowIndex)
        {
            List<int> szamok = new List<int>();

            for (int col = 0; col < ColumnCount; col++)
            {
                if (GetType(rowIndex, col) == CellType.Number)
                {
                    szamok.Add(Convert.ToInt32(this[rowIndex, col]));
                }
            }

            return szamok.Average();
        }

        public override void ClearColumn(int column)
        {
            FillColumn(column - 1 , "");
        }

        public override void ClearRow(int row)
        {
            FillRow(row - 1, "");
        }

        public override void DeleteColumn(int column)
        {
            throw new NotImplementedException();
        }

        public override void DeleteRow(int row)
        {
            throw new NotImplementedException();
        }

        public void FillColumn(int colIndex, string value)
        {
            for (int row = 0; row < RowCount; row++)
            {
                this[row, colIndex] = value;
            }
        }

        public void FillRow(int rowIndex, string value)
        {
            for (int col = 0; col < ColumnCount; col++)
            {
                this[rowIndex, col] = value;
            }
        }

        public override CellType GetType(int rowIndex, int columnIndex)
        {

            int szam;
            if (int.TryParse(this[rowIndex, columnIndex], out szam))
            {
                return CellType.Number;
            }

            DateTime date;
            if (DateTime.TryParse(this[rowIndex, columnIndex], out date))
            {
                return CellType.Date;
            }

            bool nigga;
            if (bool.TryParse(this[rowIndex, columnIndex], out nigga))
            {
                return CellType.Bool;
            }

            return CellType.String;
        }

        public override bool IsValidCell(int rowIndex, int columnIndex)
        {
            if (IsValidIndexForColumn(columnIndex) && IsValidIndexForRow(rowIndex))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public override bool IsValidIndexForColumn(int columnIndex)
        {
            if (columnIndex >= 0 && columnIndex < ColumnCount)
            {
                return true;
            }

            else { return false; }
        }

        public override bool IsValidIndexForRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < RowCount)     
            {
                return true;
            }

            else { return false; }
        }

        public double SumColumn(int columnIndex)
        {
            List<int> szamok = new List<int>();

            for (int row = 0; row < RowCount; row++)
            {
                if (GetType(row, columnIndex) == CellType.Number)
                {
                    szamok.Add(Convert.ToInt32(this[row, columnIndex]));
                }
            }

            return szamok.Sum();
        }

        public double SumRow(int rowIndex)
        {
            List<int> szamok = new List<int>();

            for (int col = 0; col < ColumnCount; col++)
            {
                if (GetType(rowIndex, col) == CellType.Number)
                {
                    szamok.Add(Convert.ToInt32(this[rowIndex, col]));
                }
            }

            return szamok.Sum();
        }

        public void SwapColumns(int column1, int column2)
        {
            string temp;
            for (int row = 0; row < RowCount; row++)
            {
                temp = this[row, column1 - 1];
                this[row, column1 - 1] = this[row, column2 - 1];
                this[row, column2 - 1] = temp;
            }
        }

        public void SwapRows(int row1, int row2)
        {
            string temp;
            for (int col = 0; col < ColumnCount; col++)
            {
                temp = this[row1, col];
                this[row1 - 1, col] = this[row2 - 1, col];
                this[row2 - 1, col] = temp;
            }
        }
    }
}
