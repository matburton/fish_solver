
using System;
using System.Collections.Generic;
using System.Linq;

namespace FishSolver.Core.Domain
{
    public sealed class PieceSlot
    {
        public PieceSlot(IEnumerable<FishPiece> possiblePieces)
        {
            if (possiblePieces == null)
            {
                throw new ArgumentNullException(nameof(possiblePieces));
            }

            possiblePieces = possiblePieces.ToArray();

            if (possiblePieces.Contains(null))
            {
                throw new ArgumentException("Contained null",
                                            nameof(possiblePieces));
            }

            _possiblePieces = new HashSet<FishPiece>(possiblePieces);
        }

        public bool IsPossible => _possiblePieces.Any();

        public IEnumerable<FishPiece> PossiblePieces => _possiblePieces;

        public void RemovePiece(FishPiece piece) => _possiblePieces.Remove(piece);

        public FishPiece Single => _possiblePieces.Count == 1
                                 ? _possiblePieces.Single()
                                 : null;

        public PieceSlot Clone() => new PieceSlot(_possiblePieces);

        private readonly ISet<FishPiece> _possiblePieces;
    }
}