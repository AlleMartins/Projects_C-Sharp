namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        private readonly string _seed;
        private readonly string _name;
        private readonly int _ordinal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            this._name = name;
            this._ordinal = ordinal;
            this._seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        // TODO improve
        public string GetSeed() => this._seed;

        // TODO improve
        public string GetName() => this._name;
        
        // TODO improve
        public int GetOrdinal() => this._ordinal;
        
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"{this.GetType().Name}(Name={this.GetName()}, Seed={this.GetSeed()}, Ordinal={this.GetOrdinal()})";

        // TODO generate Equals(object obj)
        public override bool Equals(object obj) => obj is Card card && Equals(card);

        // TODO generate GetHashCode()
        public override int GetHashCode() => HashCode.Combine(_seed, _name, _ordinal);
    }
}
