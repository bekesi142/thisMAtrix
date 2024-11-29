using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerProjekt.Models
{
    public abstract class SpreadsheetBase
    {
        public enum CellType
        {
            String,
            Number,
            Date,
            Bool
        }

        const int MAX_ROW_NUMBER = 5000;
        const int MAX_COLUMN_NUMBER = 100;
        //todo - Készítsen MIN_ROW_NUMBER és MIN_COLUMN_NUMBER néven konstansokat. A legkevesebb sor 10, a elgkevesebb oszlop pedig 20 lehet!

        private string[,] cells;

        /// <summary>
        /// Táblázatot létrehozó konstruktor. A cellák üres stringet tartalmaznak a létrehozáskor.
        /// </summary>
        /// <param name="numberOfRows">Sorok száma</param>
        /// <param name="numberOfColumns">Oszlopok száma</param>
        /// <exception cref="ArgumentOutOfRangeException">Megengedet tartományon kivüli méret!</exception>///
        public SpreadsheetBase(int numberOfRows, int numberOfColumns)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(numberOfRows, MAX_ROW_NUMBER, "numberOfRows");
            //todo A méretekre végezzen további hibavizsgálatot!
            cells = new string[numberOfRows, numberOfColumns];
            ResetTable();
        }
        //todo 1) - [SpreadsheetBase] Készítsen paraméter nélküli konstruktort, amit a meglévő konstruktorra vezet vissza!
        // Ebben az esetben 26 oszlop és 500 sor legyen a létrejövő táblázatban!

        /// <summary>
        /// A táblázat cellájához biztosít írási és olvasási hozzáférést
        /// </summary>
        /// <param name="rowIndex">A cella sorának indexe</param>
        /// <param name="columnIndex">A cella oszlopának indexe</param>
        /// <returns>A cella tartalma</returns>
        /// <exception cref="IndexOutOfRangeException ">Ha az indexek kivül esnek az aktuális tábla méretén</exception>
        public string this[int rowIndex, int columnIndex]
        {
            get
            {
                //todo Hibavizsgálat az indexekre!
                // Hiba esetén IndexOutOfRangeException kiváltása!


                return this[rowIndex, columnIndex];
            }
            set
            {
                //todo Hibavizsgálat az indexekre!
                // Hiba esetén IndexOutOfRangeException kiváltása!
                this[rowIndex, columnIndex] = value;
            }
        }



        /// <summary>
        /// Megvizsgálja, hogy valós-e a sorindex
        /// </summary>
        /// <param name="rowIndex">Vizsgálandó sor indexe</param>
        /// <returns>true - létezik ilyen sor</returns>
        public abstract bool IsValidIndexForRow(int rowIndex);

        public abstract bool IsValidIndexForColumn(int rowIndex);

        /// <summary>
        /// Megvizsgálja, hogy létezik-e a megadott cella a táblázatban.
        /// </summary>
        /// <param name="rowIndex">Cella sorának száma (0-tól induló számozás)</param>
        /// <param name="columnIndex">Cella oszlopának száma (0-tól induló számozás)</param>
        /// <returns>true - érvényes a hivatkozás, false - nem létezik ilyen cella</returns>
        /// <exception cref="IndexOutOfRangeException ">Ha az indexek kivül esnek az aktuális tábla méretén</exception>
        public abstract bool IsValidCell(int rowIndex, int columnIndex);
        //TODO Tipp - Vezesse át az előző két függvényre!


        /// <summary>
        /// A táblázatot alapértelmezett állapotba hozza. Minden cellát üressé tesz!
        /// </summary>
        public void ResetTable()
        {
            for (int rowIndex = 0; rowIndex < cells.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < cells.GetLength(1); colIndex++)
                {
                    cells[rowIndex, colIndex] = "";
                }
            }
        }

        /// <summary>
        /// Kitörli a táblázat megadott sorát. A alatta lévő sorok eggyel fentebb kerülnek.
        /// </summary>
        /// <param name="row">A törlendő sor indexe</param>
        /// <exception cref="IndexOutOfRangeException ">Ha az index kivül esik a megengedett tartományon</exception>
        public abstract void DeleteRow(int row);

        // TODO TIPP!
        // Az implementáció során vegye figyelembe, hogy a kétdimenziós tömb nem átméretezhető!
        // Egy új, kisebb méretű tömböt kell létrehozni és abba átmásolni a régi megmaradó elemeket.
        // A másolás után az új tömbbel foogunk tovább dolgozni.


        /// <summary>
        /// Kitörli a táblázat megadott oszlopát. Az utána következő oszlopok eggyel balra kerülnek. A szerkezet változik!
        /// </summary>
        /// <param name="column">A törlendő oszlop indexe</param>
        /// <exception cref="IndexOutOfRangeException ">Ha az index kivül esik a megengedett tartományon</exception>
        public abstract void DeleteColumn(int column);


        /// <summary>
        /// Kiüríti a táblázat megadott sorát (törli annak tartalmát). A szerkezet NEM változik!
        /// </summary>
        /// <param name="row">A sor indexe</param>
        /// <exception cref="IndexOutOfRangeException ">Ha az index kivül esik a megengedett tartományon</exception>
        public abstract void ClearRow(int row);


        /// <summary>
        /// Kiüríti a táblázat megadott oszlopát (törli annak tartalmát). A szerkezet NEM változik!
        /// </summary>
        /// <param name="column">Az oszlop indexe</param>
        /// <exception cref="IndexOutOfRangeException ">Ha az index kivül esik a megengedett tartományon</exception>
        public abstract void ClearColumn(int column);

        /// <summary>
        /// Megadja a meghatározott cella típusát
        /// </summary>
        /// <param name="rowIndex">A cella sorának indexe</param>
        /// <param name="columnIndex">A cella oszlopának indexe</param>
        /// <returns>A cella típusa, ami lehet CellType.String, CellType.Number, CellType.Date, CellType.Bool</returns>
        /// <exception cref="IndexOutOfRangeException ">Ha az indexek kivül esnek az aktuális tábla méretén</exception>
        public abstract CellType GetType(int rowIndex, int columnIndex);
    }
}


