using System.Collections.ObjectModel;
using System.ComponentModel;
using SudokuBasis;
using System; 

namespace SA_Week4_Sudoku.View
{
    public class Cell: INotifyPropertyChanged 
    {
        private int row;
        private int col;
        public Cell(int c, int r, int maxval)
        {
            this.row = r;
            this.col = c;
            possibleValuesValue = new ObservableCollection<int?>();
            possibleValuesValue.Add(null);
            for (int i = 1; i <= maxval; i++)
            {
                possibleValuesValue.Add(i);  
            }
        }

        public int getRow(){
            return row;
        }

        public int getCol()
        {
            return col;
        }
        bool readOnlyValue = false;
        public bool ReadOnly
        {
            get
            {
                return readOnlyValue; 
            }
            set
            {
                if (readOnlyValue != value)
                {
                    readOnlyValue = value;
                    if (PropertyChanged != null) PropertyChanged(this, 
                        new PropertyChangedEventArgs("ReadOnly"));
                }
            }
        }
        int? valueValue = null;
        public int? Value
        {
            get
            {
                return valueValue; 
            }
            set
            {
                if (valueValue == null || valueValue != value)
                {
                    valueValue = value;
                    if (PropertyChanged != null) PropertyChanged(this, 
                        new PropertyChangedEventArgs("Value"));  
                }
            }
        }
        ObservableCollection<int?> possibleValuesValue;
        public ObservableCollection<int?> PossibleValues
        {
            get
            {
                return possibleValuesValue; 
            }
        }
        bool isValidValue = true;
        public bool IsValid
        {
            get
            {
                return isValidValue;
            }
            set
            {
                if (isValidValue != value)
                {
                    isValidValue = value;
                    if (PropertyChanged != null) PropertyChanged(this,
                        new PropertyChangedEventArgs("IsValid"));
                }
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

    public class InnerGrid: INotifyPropertyChanged 
    {
        ObservableCollection<ObservableCollection<Cell>> Rows;
        public ObservableCollection<ObservableCollection<Cell>> GridRows
        {
            get
            {
                return Rows;
            }
        }
        public InnerGrid(int startC, int startR, int size)
        {
            Rows = new ObservableCollection<ObservableCollection<Cell>>();
            for (int c = 0; c < size; c++)
            {
                ObservableCollection<Cell> Col = new ObservableCollection<Cell>();
                for (int r = 0; r < size; r++)
                {
                    Cell cell = new Cell(c + startC, r + startR, size * size);
                    cell.PropertyChanged += new PropertyChangedEventHandler(c_PropertyChanged);
                    Col.Add(cell);  
                }
                Rows.Add(Col);  
            }
        }

        void c_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Board.isInitialized == false) // skip cell events if the board isn't initialised yet.
                return;

            if (e.PropertyName == "Value")
            {
                bool valid = CheckIsValid();

                foreach (ObservableCollection<Cell> row in Rows)
                {
                    foreach (Cell cell in row)
                    {
                        cell.IsValid = valid;
                    }
                }
               
                isValidValue = valid;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));  
            }
        }
        bool isValidValue = true;
        public bool IsValid
        {
            get
            {
                return isValidValue; 
            }
        }
        private bool CheckIsValid()
        {
            bool[] used = new bool[Rows.Count * Rows.Count];      
            foreach (ObservableCollection<Cell> innerGrid in Rows)
            {
                foreach (Cell cell in innerGrid)
                {
                    if (cell.Value.HasValue)
                    {
                        if (used[cell.Value.Value - 1])
                        {
                            return false; //this is a duplicate
                        }
                        else
                        {
                            used[cell.Value.Value - 1] = true; 
                        }
                    }
                 }
            }
            return true;
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public Cell this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows.Count) throw new ArgumentOutOfRangeException("row", row, "Invalid Row Index");
                if (col < 0 || col >= Rows.Count) throw new ArgumentOutOfRangeException("col", col, "Invalid Column Index");
                return Rows[row][col];
            }
        }


    }

    public class Board : INotifyPropertyChanged
    {
        private SudokuWrapper gameData = new SudokuBasis.SudokuWrapper();
        private int size;
        ObservableCollection<ObservableCollection<InnerGrid>> Rows;
        public ObservableCollection<ObservableCollection<InnerGrid>> GridRows
        {
            get
            {
                return Rows;
            }
        }

        private static Boolean initialized;
        public static Boolean isInitialized
        {
            get { return initialized; }
        }

        public Board(int totalsize)
        {
            initialized = false;
            size = (int)Math.Sqrt(totalsize);
            Rows = new ObservableCollection<ObservableCollection<InnerGrid>>();
            for (int c = 0; c < size; c++)
            {
                ObservableCollection<InnerGrid> Col = new ObservableCollection<InnerGrid>();
                for (int r = 0; r < size; r++)
                {
                    InnerGrid g = new InnerGrid(c * 3, r * 3, size);
                    g.PropertyChanged += new PropertyChangedEventHandler(g_PropertyChanged);
                    Col.Add(g);
                    for (int y = 0; y < g.GridRows.Count; y++)
                    {
                        for (int x = 0; x < g.GridRows.Count; x++)
                        {
                            g.GridRows[y][x].PropertyChanged += new PropertyChangedEventHandler(c_PropertyChanged);
                        }
                    }


                }
                Rows.Add(Col);
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int value = gameData.get(col, row);
                    if (value == 0) // skip empty fields
                        continue;

                    InnerGrid innergrid = Rows[col / Rows.Count][row / Rows.Count];
                    foreach (ObservableCollection<Cell> cells in innergrid.GridRows)
                    {
                        foreach (Cell c in cells)
                        {
                            if (c.getRow() == row && c.getCol() == col)
                            {
                                c.Value = value;
                                c.ReadOnly = true;
                            }
                        }
                    }
                }
            }

            initialized = true;
        }

        public void Solve()
        {
            int emptyFieldCount = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int value = gameData.get(col, row);
                    if (value != 0) // skip non-empty fields
                        continue;

                    emptyFieldCount++;
                }
            }
            
            for(int numHints = 0; numHints < emptyFieldCount - 2; numHints++)
            {
                short col = 0, row = 0, value = 0;
                if (gameData.getHint(ref col, ref row, ref value)) // hint
                {
                    InnerGrid innergrid = Rows[col / Rows.Count][row / Rows.Count];
                    foreach (ObservableCollection<Cell> cells in innergrid.GridRows)
                    {
                        foreach (Cell c in cells)
                        {
                            if (c.getRow() == row && c.getCol() == col)
                            {
                                c.Value = value;
                                c.ReadOnly = true;
                            }
                        }
                    }
                }
                else
                {
                    // Error
                }
            }
        }

        void g_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (isInitialized == false) // Skip propertyChanged events if the board isn't initialised yet.
                return;

            if (e.PropertyName == "IsValid")
            {
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        InnerGrid innergrid = Rows[a][b];
                        foreach (ObservableCollection<Cell> cells in innergrid.GridRows)
                        {
                            foreach (Cell c in cells)
                            {
                                c.IsValid = true;
                            }
                        }
                    }
                }

                bool valid = true;
                int totalsize = Rows.Count * Rows.Count;
                for (int c = 0; c < totalsize; c++)
                {
                    bool rowValid = CheckRowIsValid(c);
                    for (int r = 0; r < totalsize; r++)
                    {
                        bool innerGridValid = Rows[c / Rows.Count][r / Rows.Count].IsValid;
                        if (this[c, r].IsValid == true)
                        {
                            this[c, r].IsValid = rowValid & innerGridValid;
                        }
                    }

                    bool colValid = CheckColumnIsValid(c);
                    for (int r = 0; r < totalsize; r++)
                    {
                        bool innerGridValid = Rows[r / Rows.Count][c / Rows.Count].IsValid;
                        if (this[r, c].IsValid == true)
                        {
                            this[r, c].IsValid = colValid & innerGridValid;
                        }
                    }
                }
                isValidValue = valid;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
            }
        }

        void c_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                Cell cell = (Cell)sender;
                gameData.set(cell.getCol(), cell.getRow(), (int)cell.Value);
            }
        }
        bool isValidValue = true;
        public bool IsValid
        {
            get
            {
                return isValidValue;
            }
        }
        private bool CheckRowIsValid(int row)
        {
            int width = Rows.Count * Rows.Count;
            bool[] used = new bool[width];
            for (int i = 0; i < width; i++)
            {
                Cell c = this[row, i];
                if (c.Value.HasValue)
                {
                    if (used[c.Value.Value - 1])
                    {
                        return false;
                    }
                    else
                    {
                        used[c.Value.Value - 1] = true;
                    }
                }
            }
            return true;
        }
        private bool CheckColumnIsValid(int col)
        {
            int height = Rows.Count * Rows.Count;
            bool[] used = new bool[height];
            for (int i = 0; i < height; i++)
            {
                Cell c = this[i, col];
                if (c.Value.HasValue)
                {
                    if (used[c.Value.Value - 1])
                    {
                        return false;
                    }
                    else
                    {
                        used[c.Value.Value - 1] = true;
                    }
                }
            }
            return true;
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public Cell this[int row, int col]
        {
            get
            {
                int totalsize = Rows.Count * Rows.Count;
                if (row < 0 || row >= totalsize) throw new ArgumentOutOfRangeException("row", row, "Invalid Row Index");
                if (col < 0 || col >= totalsize) throw new ArgumentOutOfRangeException("col", col, "Invalid Column Index");
                return Rows[row / Rows.Count][col / Rows.Count][row % Rows.Count, col % Rows.Count];
            }
        }
    }
}
