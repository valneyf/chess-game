namespace tabuleiro
{
    class Posicao
    {
        public int row { get; set; }
        public int column { get; set; }

        public Posicao(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string ToString()
        {
            return row
                + ", "
                + column;
        }
    }
}
