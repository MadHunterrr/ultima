CREATE TABLE [dbo].[FamilyChildrens] (
    [FamilyChildrenId] [int] NOT NULL IDENTITY,
    [FamilyChildrenName] [nvarchar](max),
    [FamilyChildreGeburtsdatum] [nvarchar](max),
    [FamilyChildrenBenefit] [int] NOT NULL,
    [FamilyChildrenRevenu] [int] NOT NULL,
    [FamilyChildrenKindergeId] [int] NOT NULL,
    [FamilyChildrenUnterhaltseinnahmen] [int] NOT NULL,
    [FamilyUnion_FamilyUnionId] [int],
    CONSTRAINT [PK_dbo.FamilyChildrens] PRIMARY KEY ([FamilyChildrenId])
)
CREATE INDEX [IX_FamilyUnion_FamilyUnionId] ON [dbo].[FamilyChildrens]([FamilyUnion_FamilyUnionId])
CREATE TABLE [dbo].[FamilyUnions] (
    [FamilyUnionId] [int] NOT NULL IDENTITY,
    [FamilyUnionFirstMemberId] [int] NOT NULL,
    [FamilyUnionSecondMemberId] [int] NOT NULL,
    [FamilyUnionFinancialSituationid] [int] NOT NULL,
    CONSTRAINT [PK_dbo.FamilyUnions] PRIMARY KEY ([FamilyUnionId])
)
CREATE TABLE [dbo].[FamilyFinancialSituations] (
    [FamilyFinancialSituationId] [int] NOT NULL IDENTITY,
    [FamilyFinancialSituationBankSparguthaben] [nvarchar](max),
    [FamilyFinancialSituationWertpapiereAktien] [nvarchar](max),
    [FamilyFinancialSituationBausparvertrag] [nvarchar](max),
    [FamilyFinancialSituationLebensRentenversicherung] [nvarchar](max),
    [FamilyFinancialSituationSparplane] [nvarchar](max),
    [FamilyFinancialSituationSonstigesVermogen] [nvarchar](max),
    [FamilyFinancialSituationEinkunfteNebentatigkeit] [nvarchar](max),
    [FamilyFinancialSituationEnbefristeteZusatzrente] [nvarchar](max),
    [FamilyFinancialSituationEhegattenunterhalt] [nvarchar](max),
    [FamilyFinancialSituationVariableEinkunfte] [nvarchar](max),
    [FamilyFinancialSituationSonstigeEinnahmen] [nvarchar](max),
    [FamilyFinancialSituationMietausgaben] [nvarchar](max),
    [FamilyFinancialSituationUnterhaltsverpflichtungen] [nvarchar](max),
    [FamilyFinancialSituationPrivateKrankenversicherung] [nvarchar](max),
    [FamilyFinancialSituationSonstigeAusgaben] [nvarchar](max),
    [FamilyFinancialSituationSonstigeVersicherungsausgaben] [nvarchar](max),
    [FamilyFinancialSituationRatenkreditLeasing] [nvarchar](max),
    [FamilyFinancialSituationPrivatesDarlehen] [nvarchar](max),
    [FamilyFinancialSituationSonstigeVerbindlichkeiten] [nvarchar](max),
    CONSTRAINT [PK_dbo.FamilyFinancialSituations] PRIMARY KEY ([FamilyFinancialSituationId])
)
CREATE TABLE [dbo].[FamilyMems] (
    [FamilyMemId] [int] NOT NULL IDENTITY,
    [FamilyMemFirstName] [nvarchar](max),
    [FamilyMemSecondName] [nvarchar](max),
    [FamilyMemCode] [int] NOT NULL,
    [FamilyMemComment] [nvarchar](max),
    [FamilyMemArt] [int] NOT NULL,
    [FamilyMemCountry] [int] NOT NULL,
    [FamilyMemDate] [nvarchar](max),
    [FamilyMemFamily] [int] NOT NULL,
    [FamilyMemNetto] [int] NOT NULL,
    [FamilyMemOrt] [nvarchar](max),
    [FamilyMemPhone] [nvarchar](max),
    [FamilyMemPlz] [int] NOT NULL,
    [FamilyMemSeit] [nvarchar](max),
    [FamilyMemSex] [int] NOT NULL,
    [FamilyMemStreetName] [nvarchar](max),
    [FamilyMemStreetNum] [int] NOT NULL,
    CONSTRAINT [PK_dbo.FamilyMems] PRIMARY KEY ([FamilyMemId])
)
ALTER TABLE [dbo].[FamilyChildrens] ADD CONSTRAINT [FK_dbo.FamilyChildrens_dbo.FamilyUnions_FamilyUnion_FamilyUnionId] FOREIGN KEY ([FamilyUnion_FamilyUnionId]) REFERENCES [dbo].[FamilyUnions] ([FamilyUnionId])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201705250939184_ModelContextMigration', N'WebApplication1.Migrations.Configuration',  0x1F8B0800000000000400CD5CCB6EE33816DD0FD0FF2068D53D48DB496A3313C4DD48B99246509507E24AF5603605DAA26D2212A5A6A8C0E9C17CD92CE693E617E6522F4B22694B146507BD4959E4B9879797CFCBD3FFFBCF7F2F7FDD04BEF38A594C423A71CF46A7AE83E922F4085D4DDC842F7FFE9BFBEB2F3FFCE5F2DA0B36CEB7A2DC07510E6AD278E2AE398F2EC6E378B1C6018A470159B0300E977CB4088331F2C2F1F9E9E9DFC76767630C102E6039CEE55342390970FA0FF8E734A40B1CF104F977A187FD38FF1DBECC5254E71E05388ED0024FDCDFF1FC2A8A7CB2401CA89C8DB21AAE73E513046C66D85FBA0EA234E469818BE718CF380BE96A16C10FC8FFFA166128B7447E8CF3365C6C8BB76DCEE9B968CE785BB1805A24310F838E80671F72FF8C9BD58DBCEC96FE030F5E83A7F99B6875EAC5897B8302E2BF4DD7C4F71806034D9317539F89E23A578FEA00274EA3D8491926104DE2BF13679AF83C61784271C219F24F9CC7640EE53FE3B7AFE10BA6139AF87E9534D0866FB51FE0A747164698F1B727BC5436E5D6739D711D65DC842941B40859D36F29FF70EE3AF7400CCD7D5CC64BC54D331E32FC1BA698218EBD47C43966D0DDB71E4E3D2E71D96959FC56D8867085D1E73A7768F305D3155F4F5CF8D3756EC8067BC52F399F674A60B04225CE12DCC9E46F789E301E7B8827C1612DD38FE0B425E1FB7CDD05F209BF629AD844FC4CA887D90AEF8F892EA8CF14A2648D7C1E6342295A0762047682BF47AF649546A0D210748B98359EB09F9689D724CA26C551E5FBF73A29983D6F58183C857E1DA659ECFB57040E11FD16EE2F3B0B13B668D0BF1C6F67A3167354DE16C3092AAD7DFCD929A5613E3595D50F3B2FA5666F088BF91D0EE698D9190529EA0C2F42EA5987BD2114D1052CF033021B09E109D2157CCFD0AA0C976186573164DA0CAF6228F6185EB2C78CC79A0C75FC812773321F856AACC30E4999C347445F6057CB56095FA3F976251978199789FC0E65221411CCF0D50B274764F21125704E6070A081885A1D8DC6170CDD113F41F7629A1EAE60DBCE127A3C42224C221FD1436D32150C60B6E46485639806827075C418B926F425A14B8EEF452F8921BA7AC1DBEDE8E1F9D0395E321273CCF13F9318F13F99089CE3F159E39598A268526C568F46E51B62444CAA65971D3D7CAF9BDBF68333B92398C32CB73AEA8CBF3DC7C0F4162D61D55E7398DF8EC8E8919157585D3F335814DFCBA49BC7CCD5B17BAB20F2ADE295F8E831F404DD455F18F608FF82514C8ED85379F0C49F10F3F1FA7DF4D49C504F8C2BB1365967D4F1A800A735E3B301D43DFE61004898EFFEF3CA87DDEE83D1F4FC7DC09B4130991DCE0F6B730A556C5C03A450012CCD87DAAF80C12B66E51A33A50EDB2DF66609ED133AD85E49046AFA8725EAF798F3D012D6033B602C3CAEC3839DAF8439FF4F4B5E9A1DEEF4935ADBD8E2CD19C6879E20339BDB9C499B36E856DBAB380E61F9178B867CA129DD22D6095E53CFE970A598B9A77151098E825597887519D84DDCD3D1E84CF2443B43656AA069689B68ACDBFA6BD3451567C83B9269080775022B6AEEA77487217EC41BAED8993CC738DF9CC479FF36DB24406798EB2E78B7FDA5698CE4241560EA2A3D5ADE07ADA0E4ADA21E5775B1DBCA08C4B71E35DD0336602A7DA66CBB7C135EA9D1E2E2BCB9BDEB16F465239BFD3136C32D625CC2ADB4AFB9C3AC7B4831279491BD7DF430CE5E3D14AF23C69AE7119777288A60BAAB3C97C87F7166D95B89E9CFB3EE0F08820C63BC8815EF084AB6A525D8EBA2156E7C05D3C034DDBFC24E04CD919811A75E2015AB8D634D8816A6D44355EECA227A8B7AE2EFAC6EAB070D4DC4AD5B6FA0A5627B99361A6BA34006481FB2201FB1BDAF0FA6A19F04B4DDEB86F6C8D912A9C7CEBE1BA2D71F12688DD48B99B6A47C3AA06F4C59C4D446F196406FA228616AA1FAB6406FA55ACAD492F2BD81DEA4B2B86CFB72DC1811CD4138964661635A6C0EEE0E433F9FC4AD8DFB6C15361DF49ADABB7BA74CEACB3DA1792ED012B391B1D7C0374A19596A66F135A69AC50C5BA54AED6B1BA72AFCCE6258B59BB316D08AED9F6974B781DADD81EACCB9DC776DB2F526D6E41C791BDB72ADFE4C1449F2365414D56C78A59E266FE7937A9DFE2CF459F2367CF4B5FB33ABA4CBDB50A914B7605B4E94B7E22057EBCF459B2A6FC3485BD9022F5DCABC152F5D650BBC14A9F3569414F5FAB35164CFDB905154B317D5D7BBB6A1ADAAF5E752CFA0B7A151AFD19FC18EF4791B3A3BAAF7E7B62B91DE86DCAEFAF6E2E8AA53FFC9B5EC31D124D5BBD0D240F4E7A84AB1B721A6AA672DB22A59F60EF154A965B5EF9A69F68EFDD6ACFECE0E1AE98DAEB59385B802363D4A28EBEEEEB73CEF2EF788329BDF0AAF925257C256BE1BA057B3E74AF86A0103FC2C53AE44CE3E1961E629730D6CFED50039CD8D2B51D32F465CF31CB9866BFED50039CB972B61B34F26B19667C5D581967F34C0CD13E44AD8FC9B01EA83B6B71E0C7B2BCF872B31F36F26A822EDADC6145F8C46ADFA44537E32C2DC68213766889564B71AB852C01C5F7D875FFF7EF835AE9E45D3DE0ACBE9C62E77C072ED6E791E9145D45F62EAB294B22F7B5C1C7FDF73892CFC5C72EC473F4F8676A26F9EE9DA497C0A6B2A491F51DCC6E21D46F906C3C84BCD9CAD1C9052EAB659A41C0E650AB791AABDCCD3A6FBE5EE521E352BE23AE08C57E2891CEAEC2DE638188902A3D91FFED427E98A5D14B843942C71CCB36794EEF9E9D979432DFF7E94EBE338F6FC4EF275E317A143A8C689F0FBDED79FBD04C4D9FC9E99A3AF882DD688FD18A0CD4F555C2B62707BE84DC177EA268B72EFFE78B2D8BB3FE60EA9B739B872FEAA804A2FA16EA1619B89FBAF14E5C2B9FDC7772DD089F3C0C00B17CEA9F3EFDDFD6DA4E3361EA97615D4038E51BD68BA6787AB25D33D417709A6F743F7D71A1BC7C3A184BD03464A7B2DAF8559B8835E77106B6A4DEE20A6F6E96E07312A696B87B1A2D3CF0E626D8F4676189BBB75B0C3D8D46A5D0731A7D5B30E1A32926675106B2A5DEA2086F66A4F07B1BA5F5F3A681F3635A4831ADBA9131DC4B25E0B3A64674A7ACFA1BDAAD67476B06AA0DB34DE67D9D34C0EB89352C9242DF4A2520A6907B72A7734DFC2CB62473BEC2A82C69EE46A72C65E585531A39D5616D9170BE46A72C55E4815B1A29D56D604899620B7A2C35E6D9DD9DD4CD66585FD9849A2424BFC9AC241F333B675D9A0557DE0562367AA050450588BB0D8FDC33A3A15CB2743444E2AC12A0E2B6D847C458BE4BC44C7EB25E1FED240F3CB271C612A162E75CB3B1ADF9FB529ED35D6E27D6EEAA8AA94455B9AA726EABBF8FDAAC92C793171BDB99832B3C097B26EEDA595FB94957A736A25606BED6527E9A59E8552D4D956A9B95BA8A9379A893CDFA39053A7D86C21D86CC6A02A5D3B8836534EE4C1A8ACFCDFAD61AA88C96A0B219295142F6AE3B12C734B97613153341815451ACBCB1D9CB93D18ACB06D234BB4E0F07981E3ECFCF40DF90914B90EE6D8BBA50F098F120E4DC6C1BCFEF0444C2FBBECA702D43AE7CB87288D561B4D009A049A801FE8C7047AAAE47DA35810351062DECA4F16A22FB93861ACDE4AA47BE9AD890E28775F39DD7EC541E48B83E2039DA1576CC2ED39C65FF00A2DDE8A7CAC1E647F47D4DD7EF989A01543419C636CEBC33F2186BD60F3CBFF01181658CDE45D0000 , N'6.1.3-40302')

