using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Intex.Models
{
    public partial class Burial
    {
        [Required]
        public string BurialId { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }
        public string LowPairNs { get; set; }
        public string HighPairNs { get; set; }
        public string LowPairEw { get; set; }
        public string HighPairEw { get; set; }
        public string BurialSubplot { get; set; }
        public long? BurialDepth { get; set; }
        public long? SouthToHead { get; set; }
        public long? SouthToFeet { get; set; }
        public long? EastToHead { get; set; }
        public long? EastToFeet { get; set; }
        public string BurialSituation { get; set; }
        public string LengthOfRemains { get; set; }
        public string BurialNumber { get; set; }
        public string SampleNumber { get; set; }
        public string GenderGe { get; set; }
        public string GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string BasilarSuture { get; set; }
        public long? VentralArc { get; set; }
        public long? SubpubicAngle { get; set; }
        public long? SciaticNotch { get; set; }
        public long? PubicBone { get; set; }
        public long? PreaurSulcus { get; set; }
        public long? MedialIpRamus { get; set; }
        public long? DorsalPitting { get; set; }
        public string ForemanMagnum { get; set; }
        public string FemurHead { get; set; }
        public string HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public string BoneLength { get; set; }
        public string MedialClavicle { get; set; }
        public string IliacCrest { get; set; }
        public string FemurDiameter { get; set; }
        public string Humerus { get; set; }
        public string FemurLength { get; set; }
        public string HumerusLength { get; set; }
        public string TibiaLength { get; set; }
        public string Robust { get; set; }
        public string SupraorbitalRidges { get; set; }
        public string OrbitEdge { get; set; }
        public string ParietalBossing { get; set; }
        public string Gonian { get; set; }
        public string NuchalCrest { get; set; }
        public string ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public long? MaximumCranialLength { get; set; }
        public long? MaximumCranialBreadth { get; set; }
        public long? BasionBregmaHeight { get; set; }
        public long? BasionNasion { get; set; }
        public long? BasionProsthionLength { get; set; }
        public long? BizygomaticDiameter { get; set; }
        public long? NasionProsthion { get; set; }
        public long? MaximumNasalBreadth { get; set; }
        public long? InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public string HairTaken { get; set; }
        public string SoftTissueTaken { get; set; }
        public string BoneTaken { get; set; }
        public string ToothTaken { get; set; }
        public string TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public string ArtifactFound { get; set; }
        public string EstimateAge { get; set; }
        public string EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public string YearFound { get; set; }
        public string MonthFound { get; set; }
        public string DayFound { get; set; }
        public string HeadDirection { get; set; }
        public string OwnerId { get; set; }
        public BurialStatus Status { get; set; }
    }

    public enum BurialStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
