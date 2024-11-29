using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerProjekt.Models
{
    internal class Spreadsheet : SpreadsheetBase, ITableManipulator, IStorageHandler
    {

        public Spreadsheet(int numberOfRows, int numberOfColumns) : base(numberOfRows, numberOfColumns)
        {
        }

        public double AverageColumn(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public double AverageRow(int rowIndex)
        {
            throw new NotImplementedException();
        }

        public override void ClearColumn(int column)
        {
            throw new NotImplementedException();
        }

        public override void ClearRow(int row)
        {
            throw new NotImplementedException();
        }

        public bool CompareContent(string file1, string file2)
        {
            throw new NotImplementedException();
        }

        public bool CompareStructure(string file1, string file2)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void FillRow(int rowIndex, string value)
        {
            throw new NotImplementedException();
        }

        public override CellType GetType(int rowIndex, int columnIndex)
        {
            throw new NotImplementedException();
        }

        public override bool IsValidCell(int rowIndex, int columnIndex)
        {
            throw new NotImplementedException();
        }

        public override bool IsValidIndexForColumn(int rowIndex)
        {
            throw new NotImplementedException();
        }

        public override bool IsValidIndexForRow(int rowIndex)
        {
            throw new NotImplementedException();
        }

        public void LoadFromCsv(string fileName)
        {
            throw new NotImplementedException();
        }

        public void SaveToCsv(string fileName)
        {
            throw new NotImplementedException();
        }

        public double SumColumn(int columnIndex)
        {
            throw new NotImplementedException();
        }

        public double SumRow(int rowIndex)
        {
            throw new NotImplementedException();
        }

        public void SwapColumns(int column1, int column2)
        {
            throw new NotImplementedException();
        }

        public void SwapRows(int row1, int row2)
        {
            throw new NotImplementedException();
        }

        //
    }
}
