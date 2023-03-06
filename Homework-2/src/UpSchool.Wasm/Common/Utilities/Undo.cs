namespace UpSchool.Wasm.Common.Utilities
{
    class Undo
    {
        public string Password { get; set; }

        //T anında nesneyi tutacak olan metod.
        public UndoMemento Kaydet()
        {
            return new UndoMemento
            {
                Password = this.Password,
            };
        }

        //T anındaki nesneye bizi ulaşturacak olan metod.
        public void OncekiniYukle(UndoMemento Memento)
        {
            this.Password = Memento.Password;
        }
    }
    class UndoMemento
    {
        public string Password { get; set; }
    }
    class UndoCareTaker
    {
        public UndoMemento Memento { get; set; }
    }
}
