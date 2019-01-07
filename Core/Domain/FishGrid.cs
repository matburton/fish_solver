
using System.Collections.Generic;
using System.Linq;

namespace FishSolver.Core.Domain
{
    public sealed class FishGrid
    {
        public FishGrid(int dimension, IReadOnlyCollection<FishPiece> pieces)
        {
            _slots = new PieceSlot[dimension, dimension];

            for (var x = 0; x < dimension;  ++x)
            for (var y = 0; y < dimension; ++y)
            {
                _slots[x, y] = new PieceSlot(pieces.ToArray());
            }
        }

        private FishGrid(PieceSlot[,] slots)
        {
            _slots = new PieceSlot[slots.GetLength(0), slots.GetLength(1)];

            for (var x = 0; x < slots.GetLength(0); ++x)
            for (var y = 0; y < slots.GetLength(1); ++y)
            {
                _slots[x, y] = slots[x, y].Clone();
            }
        }

        public IEnumerable<(int x, int y)> AllCoordinates
        {
            get
            {
                for (var x = 0; x < _slots.GetLength(0); ++x)
                for (var y = 0; y < _slots.GetLength(1); ++y)
                {
                    yield return (x, y);
                }
            }
        }

        public PieceSlot GetSlot((int x, int y) c) => _slots[c.x, c.y];

        public IEnumerable<PieceSlot> GetCenterRelatedSlots(int x, int y)
        {
            for (var x2 = 0; x2 < _slots.GetLength(0); ++x2)
            {
                if (x2 != x) yield return _slots[x2, y];
            }

            for (var y2 = 0; y2 < _slots.GetLength(1); ++y2)
            {
                if (y2 != y) yield return _slots[x, y2];
            }

            if (x == y)
            {
                for (var index = 0; index < _slots.GetLength(0); ++index)
                {
                    if (x != index) yield return _slots[index, index];
                }
            }

            // ReSharper disable once InvertIf
            if (x + y == _slots.GetLength(0))
            {
                for (var x2 = 0; x2 < _slots.GetLength(0); ++x2)
                for (var y2 = _slots.GetLength(1) - 1; y2 >= 0 ; --y2)
                {
                    if (x != x2 && y != y2) yield return _slots[x, y];
                }
            }
        }

        public (PieceSlot above,
                PieceSlot right,
                PieceSlot below,
                PieceSlot left) GetSurrounding(int x, int y)
        {
            PieceSlot above = null, right = null, below = null, left = null;

            if (y != 0) above = _slots[x, y - 1];
            if (x != 0) left  = _slots[x - 1, y];

            if (y < _slots.GetLength(1) - 1) below = _slots[x, y + 1];
            if (x < _slots.GetLength(0) - 1) right = _slots[x + 1, y];

            return (above, right, below, left); 
        }

        public bool IsPossible => AllSlots.All(s => s.IsPossible);

        public bool IsSolution => AllSlots.All(s => s.Single != null);

        public FishGrid Clone() => new FishGrid(_slots);

        private IEnumerable<PieceSlot> AllSlots => AllCoordinates.Select(GetSlot);

        private readonly PieceSlot[,] _slots;
    }
}