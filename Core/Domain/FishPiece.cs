using System;

using FishSolver.Core.Domain.FishTypes;

namespace FishSolver.Core.Domain
{
    public sealed class FishPiece : IEquatable<FishPiece>
    {
        public FishPiece(CenterFishType centerFishType,
                         VerticalFishType topFishType,
                         HorizontalFishType rightFishType,
                         VerticalFishType bottomFishType,
                         HorizontalFishType leftFishType)
        {
            CenterFishType = centerFishType;
            TopFishType    = topFishType;
            RightFishType  = rightFishType;
            BottomFishType = bottomFishType;
            LeftFishType   = leftFishType;
        }

        public CenterFishType CenterFishType { get; }

        public VerticalFishType TopFishType { get; }

        public HorizontalFishType RightFishType { get; }

        public VerticalFishType BottomFishType { get; }

        public HorizontalFishType LeftFishType { get; }

        public override bool Equals(object obj) =>
         obj is FishPiece other ? Equals(other) : false;

        public override int GetHashCode()
        {
            var tuple = (CenterFishType,
                         TopFishType,
                         RightFishType,
                         BottomFishType,
                         LeftFishType);

            return tuple.GetHashCode();
        }

        public bool Equals(FishPiece other)
        {
            if (other == null) return false;

            return CenterFishType == other.CenterFishType
                && TopFishType    == other.TopFishType
                && RightFishType  == other.RightFishType
                && BottomFishType == other.BottomFishType
                && RightFishType  == other.RightFishType;
        }

        public static bool operator == (FishPiece a, FishPiece b) =>
            a == null ? b == null : a.Equals(b);

        public static bool operator != (FishPiece a, FishPiece b) => !(a == b);
    }
}