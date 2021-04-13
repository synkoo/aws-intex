using Microsoft.EntityFrameworkCore.Migrations;

namespace Intex.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burial",
                columns: table => new
                {
                    BurialId = table.Column<string>(type: "TEXT", nullable: false),
                    BurialLocationNs = table.Column<string>(type: "TEXT", nullable: true),
                    BurialLocationEw = table.Column<string>(type: "TEXT", nullable: true),
                    LowPairNs = table.Column<string>(type: "TEXT", nullable: true),
                    HighPairNs = table.Column<string>(type: "TEXT", nullable: true),
                    LowPairEw = table.Column<string>(type: "TEXT", nullable: true),
                    HighPairEw = table.Column<string>(type: "TEXT", nullable: true),
                    BurialSubplot = table.Column<string>(type: "TEXT", nullable: true),
                    BurialDepth = table.Column<long>(type: "INTEGER", nullable: true),
                    SouthToHead = table.Column<long>(type: "INTEGER", nullable: true),
                    SouthToFeet = table.Column<long>(type: "INTEGER", nullable: true),
                    EastToHead = table.Column<long>(type: "INTEGER", nullable: true),
                    EastToFeet = table.Column<long>(type: "INTEGER", nullable: true),
                    BurialSituation = table.Column<string>(type: "TEXT", nullable: true),
                    LengthOfRemains = table.Column<string>(type: "TEXT", nullable: true),
                    BurialNumber = table.Column<string>(type: "TEXT", nullable: true),
                    SampleNumber = table.Column<string>(type: "TEXT", nullable: true),
                    GenderGe = table.Column<string>(type: "TEXT", nullable: true),
                    GeFunctionTotal = table.Column<string>(type: "TEXT", nullable: true),
                    GenderBodyCol = table.Column<string>(type: "TEXT", nullable: true),
                    BasilarSuture = table.Column<string>(type: "TEXT", nullable: true),
                    VentralArc = table.Column<long>(type: "INTEGER", nullable: true),
                    SubpubicAngle = table.Column<long>(type: "INTEGER", nullable: true),
                    SciaticNotch = table.Column<long>(type: "INTEGER", nullable: true),
                    PubicBone = table.Column<long>(type: "INTEGER", nullable: true),
                    PreaurSulcus = table.Column<long>(type: "INTEGER", nullable: true),
                    MedialIpRamus = table.Column<long>(type: "INTEGER", nullable: true),
                    DorsalPitting = table.Column<long>(type: "INTEGER", nullable: true),
                    ForemanMagnum = table.Column<string>(type: "TEXT", nullable: true),
                    FemurHead = table.Column<string>(type: "TEXT", nullable: true),
                    HumerusHead = table.Column<string>(type: "TEXT", nullable: true),
                    Osteophytosis = table.Column<string>(type: "TEXT", nullable: true),
                    PubicSymphysis = table.Column<string>(type: "TEXT", nullable: true),
                    BoneLength = table.Column<string>(type: "TEXT", nullable: true),
                    MedialClavicle = table.Column<string>(type: "TEXT", nullable: true),
                    IliacCrest = table.Column<string>(type: "TEXT", nullable: true),
                    FemurDiameter = table.Column<string>(type: "TEXT", nullable: true),
                    Humerus = table.Column<string>(type: "TEXT", nullable: true),
                    FemurLength = table.Column<string>(type: "TEXT", nullable: true),
                    HumerusLength = table.Column<string>(type: "TEXT", nullable: true),
                    TibiaLength = table.Column<string>(type: "TEXT", nullable: true),
                    Robust = table.Column<string>(type: "TEXT", nullable: true),
                    SupraorbitalRidges = table.Column<string>(type: "TEXT", nullable: true),
                    OrbitEdge = table.Column<string>(type: "TEXT", nullable: true),
                    ParietalBossing = table.Column<string>(type: "TEXT", nullable: true),
                    Gonian = table.Column<string>(type: "TEXT", nullable: true),
                    NuchalCrest = table.Column<string>(type: "TEXT", nullable: true),
                    ZygomaticCrest = table.Column<string>(type: "TEXT", nullable: true),
                    CranialSuture = table.Column<string>(type: "TEXT", nullable: true),
                    MaximumCranialLength = table.Column<long>(type: "INTEGER", nullable: true),
                    MaximumCranialBreadth = table.Column<long>(type: "INTEGER", nullable: true),
                    BasionBregmaHeight = table.Column<long>(type: "INTEGER", nullable: true),
                    BasionNasion = table.Column<long>(type: "INTEGER", nullable: true),
                    BasionProsthionLength = table.Column<long>(type: "INTEGER", nullable: true),
                    BizygomaticDiameter = table.Column<long>(type: "INTEGER", nullable: true),
                    NasionProsthion = table.Column<long>(type: "INTEGER", nullable: true),
                    MaximumNasalBreadth = table.Column<long>(type: "INTEGER", nullable: true),
                    InterorbitalBreadth = table.Column<long>(type: "INTEGER", nullable: true),
                    ArtifactsDescription = table.Column<string>(type: "TEXT", nullable: true),
                    HairColor = table.Column<string>(type: "TEXT", nullable: true),
                    PreservationIndex = table.Column<string>(type: "TEXT", nullable: true),
                    HairTaken = table.Column<string>(type: "TEXT", nullable: true),
                    SoftTissueTaken = table.Column<string>(type: "TEXT", nullable: true),
                    BoneTaken = table.Column<string>(type: "TEXT", nullable: true),
                    ToothTaken = table.Column<string>(type: "TEXT", nullable: true),
                    TextileTaken = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionOfTaken = table.Column<string>(type: "TEXT", nullable: true),
                    ArtifactFound = table.Column<string>(type: "TEXT", nullable: true),
                    EstimateAge = table.Column<string>(type: "TEXT", nullable: true),
                    EstimateLivingStature = table.Column<string>(type: "TEXT", nullable: true),
                    ToothAttrition = table.Column<string>(type: "TEXT", nullable: true),
                    ToothEruption = table.Column<string>(type: "TEXT", nullable: true),
                    PathologyAnomalies = table.Column<string>(type: "TEXT", nullable: true),
                    EpiphysealUnion = table.Column<string>(type: "TEXT", nullable: true),
                    YearFound = table.Column<string>(type: "TEXT", nullable: true),
                    MonthFound = table.Column<string>(type: "TEXT", nullable: true),
                    DayFound = table.Column<string>(type: "TEXT", nullable: true),
                    HeadDirection = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burial", x => x.BurialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burial");
        }
    }
}
