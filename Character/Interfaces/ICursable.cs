namespace DungeonsAndDragons
{
    interface ICursable
    {
        public string CurseName { get; internal set; }
        public string CurseDescription { get; internal set; }
        public bool IsCursed { get; internal set; }
    }
}
