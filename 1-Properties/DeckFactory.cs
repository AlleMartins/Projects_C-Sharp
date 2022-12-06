namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] _seeds;

        private string[] _names;

        // TODO improve
        public IList<string> Seeds
        {
            get => _seeds.ToList();
            set => _seeds = value.ToArray();
        }

        // TODO improve
        public IList<string> Names
        {
            get => _names.ToList();
            set => _names = value.ToArray();
        }

        // TODO improve
        public int GetDeckSize() => this.Names.Count * this.Seeds.Count;

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (this._names == null || this._seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, this._names.Length)
                .SelectMany(i => Enumerable
                    .Repeat(i, this._seeds.Length)
                    .Zip(
                        Enumerable.Range(0, this._seeds.Length),
                        (n, s) => Tuple.Create(this._names[n], this._seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}
