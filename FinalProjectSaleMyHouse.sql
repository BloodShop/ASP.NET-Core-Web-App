USE master
GO
	IF exists (SELECT * FROM sysdatabases WHERE NAME='NADLAN')
			DROP DATABASE [NADLAN]
	CREATE DATABASE [NADLAN]
GO
USE [NADLAN]
CREATE TABLE [Countries] (
	CountryId INT PRIMARY KEY IDENTITY(1,1),
	CountryName nvarchar(100) UNIQUE NOT NULL,
	[Alpha-2 Code] nvarchar(2) NOT NULL 
		CONSTRAINT CHK_ALPH2	
			CHECK (LEN([Alpha-2 Code]) = 2),
	[Alpha-3 Code] nvarchar(3) NOT NULL 
		CONSTRAINT CHK_ALPH3
			CHECK (LEN([Alpha-3 Code]) = 3),
	[Numeric] char(3) NOT NULL UNIQUE 
		CONSTRAINT CHK_Numeric
			CHECK (LEN([Numeric]) = 3),
);
INSERT INTO [Countries] VALUES 
--Country name											alp-2	alp-3	numeric
('Afghanistan',											'AF',	'AFG',	'004'),
('Albania',												'AL',	'ALB',	'008'),
('Algeria',												'DZ',	'DZA',	'012'),
('American Samoa',										'AS',	'ASM',	'016'),
('Andorra',												'AD',	'AND',	'020'),
('Angola',												'AO',	'AGO',	'024'),
('Anguilla',											'AI',	'AIA',	'660'),
('Antarctica',											'AQ',	'ATA',	'010'),
('Antigua and Barbuda',									'AG',	'ATG',	'028'),
('Argentina',											'AR',	'ARG',	'032'),
('Armenia',												'AM',	'ARM',	'051'),
('Aruba',												'AW',	'ABW',	'533'),
('Australia',											'AU',	'AUS',	'036'),
('Austria',												'AT',	'AUT',	'040'),
('Azerbaijan',											'AZ',	'AZE',	'031'),
('Bahamas',												'BS',	'BHS',	'044'),
('Bahrain',												'BH',	'BHR',	'048'),
('Bangladesh',											'BD',	'BGD',	'050'),
('Barbados',											'BB',	'BRB',	'052'),
('Belarus',												'BY',	'BLR',	'112'),
('Belgium',												'BE',	'BEL',	'056'),
('Belize',												'BZ',	'BLZ',	'084'),
('Benin',												'BJ',	'BEN',	'204'),
('Bermuda',												'BM',	'BMU',	'060'),
('Bhutan',												'BT',	'BTN',	'064'),
('Bolivia (Plurinational State)',						'BO',	'BOL',	'068'),
('Bonaire, Sint Eustatius and Saba',					'BQ',	'BES',	'535'),
('Bosnia and Herzegovina',								'BA',	'BIH',	'070'),
('Botswana',											'BW',	'BWA',	'072'),
('Bouvet Island',										'BV',	'BVT',	'074'),
('Brazil',												'BR',	'BRA',	'076'),
('British Indian Ocean Territory',						'IO',	'IOT',	'086'),
('Brunei Darussalam',									'BN',	'BRN',	'096'),
('Bulgaria',											'BG',	'BGR',	'100'),
('Burkina Faso',										'BF',	'BFA',	'854'),
('Burundi',												'BI',	'BDI',	'108'),
('Cabo Verde',											'CV',	'CPV',	'132'),
('Cambodia',											'KH',	'KHM',	'116'),
('Cameroon',											'CM',	'CMR',	'120'),
('Canada',												'CA',	'CAN',	'124'),
('Cayman Islands',										'KY',	'CYM',	'136'),
('Central African Republic',							'CF',	'CAF',	'140'),
('Chad',												'TD',	'TCD',	'148'),
('Chile',												'CL',	'CHL',	'152'),
('China',												'CN',	'CHN',	'156'),
('Christmas Island',									'CX',	'CXR',	'162'),
('Cocos (Keeling) Islands',								'CC',	'CCK',	'166'),
('Colombia',											'CO',	'COL',	'170'),
('Comoros',												'KM',	'COM',	'174'),
('Congo (the Democratic Republic)',						'CD',	'COD',	'180'),
('Congo',												'CG',	'COG',	'178'),
('Cook Islands',										'CK',	'COK',	'184'),
('Costa Rica',											'CR',	'CRI',	'188'),
('Croatia',												'HR',	'HRV',	'191'),
('Cuba',												'CU',	'CUB',	'192'),
('Curaçao',												'CW',	'CUW',	'531'),
('Cyprus',												'CY',	'CYP',	'196'),
('Czechia',												'CZ',	'CZE',	'203'),
('Côte d`Ivoire',										'CI',	'CIV',	'384'),
('Denmark',												'DK',	'DNK',	'208'),
('Djibouti',											'DJ',	'DJI',	'262'),
('Dominica',											'DM',	'DMA',	'212'),
('Dominican Republic',									'DO',	'DOM',	'214'),
('Ecuador',												'EC',	'ECU',	'218'),
('Egypt',												'EG',	'EGY',	'818'),
('El Salvador',											'SV',	'SLV',	'222'),
('Equatorial Guinea',									'GQ',	'GNQ',	'226'),
('Eritrea',												'ER',	'ERI',	'232'),
('Estonia',												'EE',	'EST',	'233'),
('Eswatini',											'SZ',	'SWZ',	'748'),
('Ethiopia',											'ET',	'ETH',	'231'),
('Falkland Islands [Malvinas]',							'FK',	'FLK',	'238'),
('Faroe Islands',										'FO',	'FRO',	'234'),
('Fiji',												'FJ',	'FJI',	'242'),
('Finland',												'FI',	'FIN',	'246'),
('France',												'FR',	'FRA',	'250'),
('French Guiana',										'GF',	'GUF',	'254'),
('French Polynesia',									'PF',	'PYF',	'258'),
('French Southern Territories',							'TF',	'ATF',	'260'),
('Gabon',												'GA',	'GAB',	'266'),
('Gambia',												'GM',	'GMB',	'270'),
('Georgia',												'GE',	'GEO',	'268'),
('Germany',												'DE',	'DEU',	'276'),
('Ghana',												'GH',	'GHA',	'288'),
('Gibraltar',											'GI',	'GIB',	'292'),
('Greece',												'GR',	'GRC',	'300'),
('Greenland',											'GL',	'GRL',	'304'),
('Grenada',												'GD',	'GRD',	'308'),
('Guadeloupe',											'GP',	'GLP',	'312'),
('Guam',												'GU',	'GUM',	'316'),
('Guatemala',											'GT',	'GTM',	'320'),
('Guernsey',											'GG',	'GGY',	'831'),
('Guinea',												'GN',	'GIN',	'324'),
('Guinea-Bissau',										'GW',	'GNB',	'624'),
('Guyana',												'GY',	'GUY',	'328'),
('Haiti',												'HT',	'HTI',	'332'),
('Heard Island and McDonald Islands',					'HM',	'HMD',	'334'),
('Holy See',											'VA',	'VAT',	'336'),
('Honduras',											'HN',	'HND',	'340'),
('Hong Kong',											'HK',	'HKG',	'344'),
('Hungary',												'HU',	'HUN',	'348'),
('Iceland',												'IS',	'ISL',	'352'),
('India',												'IN',	'IND',	'356'),
('Indonesia',											'ID',	'IDN',	'360'),
('Iran (Islamic Republic)',								'IR',	'IRN',	'364'),
('Iraq',												'IQ',	'IRQ',	'368'),
('Ireland',												'IE',	'IRL',	'372'),
('Isle of Man',											'IM',	'IMN',	'833'),
('Israel',												'IL',	'ISR',	'376'),
('Italy',												'IT',	'ITA',	'380'),
('Jamaica',												'JM',	'JAM',	'388'),
('Japan',												'JP',	'JPN',	'392'),
('Jersey',												'JE',	'JEY',	'832'),
('Jordan',												'JO',	'JOR',	'400'),
('Kazakhstan',											'KZ',	'KAZ',	'398'),
('Kenya',												'KE',	'KEN',	'404'),
('Kiribati',											'KI',	'KIR',	'296'),
('Korea (the Democratic People`s Republic)',			'KP',	'PRK',	'408'),
('Korea (the Republic)',								'KR',	'KOR',	'410'),
('Kuwait',												'KW',	'KWT',	'414'),
('Kyrgyzstan',											'KG',	'KGZ',	'417'),
('Lao People`s Democratic Republic',					'LA',	'LAO',	'418'),
('Latvia',												'LV',	'LVA',	'428'),
('Lebanon',												'LB',	'LBN',	'422'),
('Lesotho',												'LS',	'LSO',	'426'),
('Liberia',												'LR',	'LBR',	'430'),
('Libya',												'LY',	'LBY',	'434'),
('Liechtenstein',										'LI',	'LIE',	'438'),
('Lithuania',											'LT',	'LTU',	'440'),
('Luxembourg',											'LU',	'LUX',	'442'),
('Macao',												'MO',	'MAC',	'446'),
('Madagascar',											'MG',	'MDG',	'450'),
('Malawi',												'MW',	'MWI',	'454'),
('Malaysia',											'MY',	'MYS',	'458'),
('Maldives',											'MV',	'MDV',	'462'),
('Mali',												'ML',	'MLI',	'466'),
('Malta',												'MT',	'MLT',	'470'),
('Marshall Islands',									'MH',	'MHL',	'584'),
('Martinique',											'MQ',	'MTQ',	'474'),
('Mauritania',											'MR',	'MRT',	'478'),
('Mauritius',											'MU',	'MUS',	'480'),
('Mayotte',												'YT',	'MYT',	'175'),
('Mexico',												'MX',	'MEX',	'484'),
('Micronesia (Federated States)',						'FM',	'FSM',	'583'),
('Moldova (the Republic)',								'MD',	'MDA',	'498'),
('Monaco',												'MC',	'MCO',	'492'),
('Mongolia',											'MN',	'MNG',	'496'),
('Montenegro',											'ME',	'MNE',	'499'),
('Montserrat',											'MS',	'MSR',	'500'),
('Morocco',												'MA',	'MAR',	'504'),
('Mozambique',											'MZ',	'MOZ',	'508'),
('Myanmar',												'MM',	'MMR',	'104'),
('Namibia',												'NA',	'NAM',	'516'),
('Nauru',												'NR',	'NRU',	'520'),
('Nepal',												'NP',	'NPL',	'524'),
('Netherlands',											'NL',	'NLD',	'528'),
('New Caledonia',										'NC',	'NCL',	'540'),
('New Zealand',											'NZ',	'NZL',	'554'),
('Nicaragua',											'NI',	'NIC',	'558'),
('Niger',												'NE',	'NER',	'562'),
('Nigeria',												'NG',	'NGA',	'566'),
('Niue',												'NU',	'NIU',	'570'),
('Norfolk Island',										'NF',	'NFK',	'574'),
('Northern Mariana Islands',							'MP',	'MNP',	'580'),
('Norway',												'NO',	'NOR',	'578'),
('Oman',												'OM',	'OMN',	'512'),
('Pakistan',											'PK',	'PAK',	'586'),
('Palau',												'PW',	'PLW',	'585'),
('Palestine',											'PS',	'PSE',	'275'),
('Panama',												'PA',	'PAN',	'591'),
('Papua New Guinea',									'PG',	'PNG',	'598'),
('Paraguay',											'PY',	'PRY',	'600'),
('Peru',												'PE',	'PER',	'604'),
('Philippines',											'PH',	'PHL',	'608'),
('Pitcairn',											'PN',	'PCN',	'612'),
('Poland',												'PL',	'POL',	'616'),
('Portugal',											'PT',	'PRT',	'620'),
('Puerto Rico',											'PR',	'PRI',	'630'),
('Qatar',												'QA',	'QAT',	'634'),
('Republic of North Macedonia',							'MK',	'MKD',	'807'),
('Romania',												'RO',	'ROU',	'642'),
('Russian Federation',									'RU',	'RUS',	'643'),
('Rwanda',												'RW',	'RWA',	'646'),
('Réunion',												'RE',	'REU',	'638'),
('Saint Barthélemy',									'BL',	'BLM',	'652'),
('Saint Helena, Ascension and Tristan da Cunha',		'SH',	'SHN',	'654'),
('Saint Kitts and Nevis',								'KN',	'KNA',	'659'),
('Saint Lucia',											'LC',	'LCA',	'662'),
('Saint Martin (French part)',							'MF',	'MAF',	'663'),
('Saint Pierre and Miquelon',							'PM',	'SPM',	'666'),
('Saint Vincent and the Grenadines',					'VC',	'VCT',	'670'),
('Samoa',												'WS',	'WSM',	'882'),
('San Marino',											'SM',	'SMR',	'674'),
('Sao Tome and Principe',								'ST',	'STP',	'678'),
('Saudi Arabia',										'SA',	'SAU',	'682'),
('Senegal',												'SN',	'SEN',	'686'),
('Serbia',												'RS',	'SRB',	'688'),
('Seychelles',											'SC',	'SYC',	'690'),
('Sierra Leone',										'SL',	'SLE',	'694'),
('Singapore',											'SG',	'SGP',	'702'),
('Sint Maarten (Dutch part)',							'SX',	'SXM',	'534'),
('Slovakia',											'SK',	'SVK',	'703'),
('Slovenia',											'SI',	'SVN',	'705'),
('Solomon Islands',										'SB',	'SLB',	'090'),
('Somalia',												'SO',	'SOM',	'706'),
('South Africa',										'ZA',	'ZAF',	'710'),
('South Georgia and the South Sandwich Islands',		'GS',	'SGS',	'239'),
('South Sudan',											'SS',	'SSD',	'728'),
('Spain',												'ES',	'ESP',	'724'),
('Sri Lanka',											'LK',	'LKA',	'144'),
('Sudan',												'SD',	'SDN',	'729'),
('Suriname',											'SR',	'SUR',	'740'),
('Svalbard and Jan Mayen',								'SJ',	'SJM',	'744'),
('Sweden',												'SE',	'SWE',	'752'),
('Switzerland',											'CH',	'CHE',	'756'),
('Syrian Arab Republic',								'SY',	'SYR',	'760'),
('Taiwan (Province of China)',							'TW',	'TWN',	'158'),
('Tajikistan',											'TJ',	'TJK',	'762'),
('Tanzania, United Republic',							'TZ',	'TZA',	'834'),
('Thailand',											'TH',	'THA',	'764'),
('Timor-Leste',											'TL',	'TLS',	'626'),
('Togo',												'TG',	'TGO',	'768'),
('Tokelau',												'TK',	'TKL',	'772'),
('Tonga',												'TO',	'TON',	'776'),
('Trinidad and Tobago',									'TT',	'TTO',	'780'),
('Tunisia',												'TN',	'TUN',	'788'),
('Turkey',												'TR',	'TUR',	'792'),
('Turkmenistan',										'TM',	'TKM',	'795'),
('Turks and Caicos Islands',							'TC',	'TCA',	'796'),
('Tuvalu',												'TV',	'TUV',	'798'),
('Uganda',												'UG',	'UGA',	'800'),
('Ukraine',												'UA',	'UKR',	'804'),
('United Arab Emirates',								'AE',	'ARE',	'784'),
('United Kingdom of Great Britain and Northern Ireland','GB',	'GBR',	'826'),
('United States Minor Outlying Islands',				'UM',	'UMI',	'581'),
('United States of America',							'US',	'USA',	'840'),
('Uruguay',												'UY',	'URY',	'858'),
('Uzbekistan',											'UZ',	'UZB',	'860'),
('Vanuatu',												'VU',	'VUT',	'548'),
('Venezuela (Bolivarian Republic)',						'VE',	'VEN',	'862'),
('Viet Nam',											'VN',	'VNM',	'704'),
('Virgin Islands (British)',							'VG',	'VGB',	'092'),
('Virgin Islands (U.S.)',								'VI',	'VIR',	'850'),
('Wallis and Futuna',									'WF',	'WLF',	'876'),
('Western Sahara',										'EH',	'ESH',	'732'),
('Yemen',												'YE',	'YEM',	'887'),
('Zambia',												'ZM',	'ZMB',	'894'),
('Zimbabwe',											'ZW',	'ZWE',	'716'),
('Åland Islands',										'AX',	'ALA',	'248')




CREATE TABLE [Cities]  ( 
	CityId INT PRIMARY KEY IDENTITY(1,1),
	CityName char(30) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES [Countries] (CountryId) NOT NULL
);
INSERT INTO [Cities] VALUES
	('Arad', 28),
	('Rehovot', 28),
	('Tel-Aviv', 28),
	('Kiryat-Gat', 28),
	('Ashkelon', 28),
	('Modi`in', 28),
	('Jerusalem', 28),
	('Netivot', 28),
	('Petah-Tikva', 28),
	('Diva', 1),
	('Colorado', 3),
	('Falta', 10),
	('Loli-Pop', 10)

-- Neighborhoods
CREATE TABLE [Neighborhoods] (
	NeighborhoodID INT PRIMARY KEY IDENTITY(1,1),
	[Name] char(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES [Cities] (CityId) NOT NULL
); -- drop table [Neighborhoods]
INSERT INTO [Neighborhoods] ([Name], CityId) VALUES
	('Leva`ot',1),
	('Halamish',1),
	('Shaked',1),
	('Rotem',1),
	('Gordon',2),
	('Moskovich',2),
	('Osishki',2),
	('Shin-Ben-Zion',2),
	('Ben-Gurion',3),
	('Herzog',3),
	('Center-TLV',3),
	('Rabin',3),
	('Simtat-Beit-Hosheva',3),
	('David-Zion',4),
	('David-Ha-Melech',4),
	('Nimol',5),
	('Kislev',6),
	('Tishrey',6),
	('Heshvan',6),
	('Ha-Kotel',7),
	('Lavi-Yehoshafat',7),
	('David-Ha-Melech',7),
	('Migdal',8),
	('Reut',8),
	('Hanosher',9),
	('Hakotel',9),
	('Haboher',10),
	('Moledet',11),
	('Rabin',11),
	('Noheg-Ba-Shalom',12),
	('Halamish',13)

CREATE TABLE [House types] (
	TypeID nchar(20) PRIMARY KEY,
); -- DROP TABLE [House types]
INSERT INTO [House types] VALUES 
	('Villa'),('Apartment'),('Single-Family'),('In-Law Suite'),
	('Carriage / Coach'),('Bungalow'),('Townhome'),('Ranch'),('Cottage')

CREATE TABLE [Companies] (
	CompanyID INT PRIMARY KEY IDENTITY(1,1),
	[Company Name] varchar(24) NOT NULL,
	Website nvarchar(124) NULL,
	[Description] ntext NULL,
); -- DROP TABLE [Companies]
INSERT INTO [Companies] ([Company Name], Website) VALUES 
	('House flippers',null),('Buy-and-hold companies',null),('iBuyers',null),('Trade-in companies',null),
	('Local investors','https://www.webuyuglyhouses.com/'), 
	('Simple Sale','https://www.homelight.com/simple'), 
	('We Buy Houses','https://webuyhouses.com/'),
	('Express Homebuyers','https://www.expresshomebuyers.com/'),
	('HomeGo','https://www.homego.com/')

CREATE TABLE [People] (
	PersonID INT PRIMARY KEY IDENTITY(1000,1),
	[First Name] nvarchar(30) NOT NULL,
	[Last Name] nvarchar(30) NOT NULL,
	CompanyID INT NULL FOREIGN KEY REFERENCES [Companies] (CompanyID),
	[Phone Number] nvarchar(100) UNIQUE NULL
	CONSTRAINT CHK_PhoneNum -- check that no number is not a digit AND IS 10 digits Atleast
		CHECK ([Phone Number] NOT LIKE '%[^0-9]%' AND LEN([Phone Number]) = 10), 
	--[Search House] bit DEFAULT(0) not NULL,
);
INSERT INTO [People] VALUES
--	 FirstName		LastName		CompanyID	Phone Number	Search House
	('Alon',		'Kolyakov',		1,			'0513901099'/*,	0*/),
	('Maize',		'Gotlib',		1,			'0532321230'/*,	1*/),
	('Dani',		'SuperMan',		1,			'0583328341'/*,	1*/),
	('Bobi',		'Batman',		1,			'0892747233'/*,	1*/),
	('Susi',		'Flash',		1,			'0563535922'/*,	0*/),
	('Gota',		'Rabota',		1,			'0513531611'/*,	1*/),
	('Noam',		'Hipo',			1/*7*/,		'0523333972'/*,	0*/),
	('Katara',		'Kamira',		1/*4*/,		'0558347238'/*,	1*/),
	('Nadin',		'Marlo',		1/*5*/,		'0583992899'/*,	0*/),
	('Woolverin',	'Motors',		1/*5*/,		'0558347213'/*,	1*/),
	('Munir',		'Angel',		1/*3*/,		'0558342243'/*,	1*/),
	('Matan',		'Dahan',		1/*2*/,		'0538273642'/*,	1*/),
	('Sabag',		'Dari',			1/*6*/,		'0573442732'/*,	0*/),
	('Kata',		'Mali',			1/*6*/,		'0523857432'/*,	1*/),
	('Zyra',		'Lomopina',		1/*6*/,		'0564638273'/*,	1*/),
	('Jax',			'Botox',		1/*9*/,		'0567746232'/*,	1*/),
	('Jayce',		'Maximus',		1/*9*/,		'0548537482'/*,	0*/),
	('Narmina',		'Minimus',		1/*9*/,		'0593537482'/*,	1*/)

CREATE TABLE [SalesMen] (
	SalesManID INT PRIMARY KEY IDENTITY(90000,1),
	CompanyID INT FOREIGN KEY REFERENCES [Companies] (CompanyID) NOT NULL, 
	--Specilized int FOREIGN KEY REFERENCES [House Types] (HouseTypeId) not null,
	[First Name] nvarchar(100) NOT NULL,
	[Last Name] nvarchar(100) NOT NULL,
	[Phone Number] nvarchar(100) UNIQUE NULL
		CONSTRAINT CHK_SalesManPhone 
			CHECK ([Phone Number] NOT LIKE '%[^0-9]%' AND LEN([Phone Number]) = 10),
	[Hire Date] datetime NOT NULL
		CONSTRAINT CHK_HireDate
			CHECK ([Hire Date] < GETDATE()),
	[Birth Date] datetime NOT NULL
		CONSTRAINT CHK_BirthDate
			CHECK (YEAR(GETDATE()) - YEAR([Birth Date]) > 18),
);
INSERT INTO [SalesMen] VALUES
--ID		CompanyID	[First Name]	[Last Name]		[Phone Number]	[Hire Date]				[Birth Date]	
/*90000*/	(1,			'Gorillax',		'Moronilo',		'0589182732',	LTRIM('20200615'),		RTRIM('19770810')),
/*90001*/	(1,			'Maya',			'Biton',		'0554536372',	LTRIM('20211010'),		RTRIM('19800812')),
/*90002*/	(1,			'Ziba',			'Nalla',		'0554111372',	LTRIM('20211130'),		RTRIM('19870116')),
/*90003*/	(1,			'Boris',		'Hargulari',	'0555514243',	LTRIM('20211213'),		RTRIM('19991210')),
/*90004*/	(1,			'Sahbak',		'Samira',		'0578789786',	LTRIM('20170819'),		RTRIM('19911016')),
/*90005*/	(1,			'Loyal',		'Peri',			'0518929481',	LTRIM('20180918'),		RTRIM('19921216')),
/*90006*/ 	(1,			'Bieber',		'Justin',		'0598898939',	LTRIM('20150101'),		RTRIM('19800202')),
/*90007*/ 	(1,			'Washingtom',	'Jorden',		'0557482332',	LTRIM('20160225'),		RTRIM('19891011')),
/*90008*/ 	(1,			'Trump',		'Donald',		'0519200392',	LTRIM('20181110'),		RTRIM('19781009')),
/*90009*/ 	(1,			'Christiano',	'Ronaldo',		'0529003912',	LTRIM('20120329'),		RTRIM('19770811')),
/*90010*/ 	(1,			'Leo',			'Messi',		'0500192039',	LTRIM('20110405'),		RTRIM('19920606')),
/*90011*/ 	(1,			'Anbi',			'Butiko',		'0599910290',	LTRIM('20220102'),		RTRIM('19920420')),
/*90012*/ 	(1,			'Alma',			'Kolirama',		'0599034928',	LTRIM('20170608'),		RTRIM('19930601')),
/*90013*/ 	(1,			'Sehara',		'Diziness',		'0561666162',	LTRIM('20211014'),		RTRIM('19850123')),
/*90014*/ 	(1,			'Shalom',		'Shabat',		'0566634731',	LTRIM('20211210'),		RTRIM('19720506')),
/*90015*/ 	(1,			'Tov',			'Shavua',		'0561723642',	LTRIM('20170908'),		RTRIM('20011011')),
/*90016*/ 	(1,			'David',		'Melech',		'0599348493',	LTRIM('20150520'),		RTRIM('19791110')),
/*90017*/ 	(1,			'Ma-man',		'Kislorod',		'0567177717',	LTRIM('20110228'),		RTRIM('19821130')),
/*90018*/ 	(1,			'Space',		'Nasa',			'0573827382',	LTRIM('20100315'),		RTRIM('19550901'))

CREATE TABLE [Experience Levels] (
	[Level] nchar(8) PRIMARY KEY);
INSERT INTO [Experience Levels] VALUES ('TYRO'),('MODERATE'),('PRO'),('CHAMP')

CREATE TABLE [Specialization] (
	SalesManID INT REFERENCES [SalesMen] (SalesManID) NOT NULL,
	TypeID nchar(20) REFERENCES [House Types] (TypeID) NOT NULL, 
	[Level] nchar(8) FOREIGN KEY REFERENCES [Experience Levels] ([Level]) NOT NULL,
	 /* Composite primary key on both columns */
	PRIMARY KEY (SalesManID, TypeID),
); 
INSERT INTO [Specialization] VALUES
--	SalesManID	HouseT		Level
	(90000,		'Bungalow',			'TYRO'),
	(90000,		'In-Law Suite',		'MODERATE'),
	(90001,		'Villa',			'PRO'),
	(90001,		'In-Law Suite',		'CHAMP'),
	(90001,		'Apartment',		'TYRO'),
	(90002,		'Apartment',		'CHAMP'),
	(90002,		'Bungalow',			'PRO'),
	(90002,		'Carriage / Coach',	'MODERATE'),
	(90003,		'Cottage',			'MODERATE'),
	(90003,		'Ranch',			'PRO'),
	(90004,		'Ranch',			'PRO'),
	(90005,		'In-Law Suite',		'CHAMP'),
	(90006,		'Apartment',		'MODERATE'),
	(90006,		'Bungalow',			'PRO'),
	(90007,		'Carriage / Coach',	'TYRO'),
	(90007,		'Ranch',			'MODERATE'),
	(90007,		'In-Law Suite',		'CHAMP'),
	(90008,		'Single-Family',	'MODERATE'),
	(90008,		'Cottage',			'MODERATE'),
	(90009,		'Single-Family',	'CHAMP'),
	(90009,		'Apartment',		'PRO'),
	(90010,		'Ranch',			'PRO'),
	(90010,		'Carriage / Coach',	'MODERATE'),
	(90011,		'Carriage / Coach',	'CHAMP'),
	(90012,		'Carriage / Coach',	'PRO'),
	(90012,		'Cottage',			'TYRO'),
	(90013,		'Carriage / Coach',	'PRO'),
	(90013,		'Apartment',		'PRO'),
	(90014,		'Townhome',			'MODERATE'),
	(90015,		'In-Law Suite',		'TYRO'),
	(90015,		'Ranch',			'PRO'),
	(90016,		'Ranch',			'MODERATE'),
	(90016,		'Townhome',			'CHAMP'),
	(90017,		'Carriage / Coach',	'TYRO'),
	(90017,		'Villa',			'CHAMP'),
	(90018,		'Carriage / Coach',	'MODERATE')

CREATE TABLE [Houses] (
	HouseID INT PRIMARY KEY IDENTITY(1,1),
	[Address] nvarchar(35) NOT NULL,
	[Built At] datetime NULL,
		CONSTRAINT CHK_BuildInDate
			CHECK ([Built At] < GETDATE() AND [Built At] > '19501230'),
	[Size (M^2)] INT NOT NULL
		CONSTRAINT CHK_Size_m2
			CHECK ([Size (M^2)] > 10),
	[Rooms] INT NOT NULL,
	CONSTRAINT CHK_Rooms
			CHECK ([Rooms] > 0 AND [Rooms] <= 10),
	[Wanted Price] MONEY NOT NULL,
	[For Sale] BIT NOT NULL DEFAULT(0),
	OwnerID INT FOREIGN KEY REFERENCES [People] (PersonID) NULL,
	TypeID nchar(20) FOREIGN KEY REFERENCES [House types] (TypeID) NOT NULL,
	NeighborhoodID INT FOREIGN KEY REFERENCES [Neighborhoods] (NeighborhoodID) NOT NULL,
); -- drop table [Houses]
INSERT INTO [Houses] VALUES 
--   Address			Build-Date				M^2		Rooms	Wanted-Price	ForSale	PersonID    HouseType			Neighbor	
	('Irusim 18/1',		LTRIM('20150101'),		107,	4,		1500000.01,		0,		1000,		'Bungalow',			1	),
	('Ayanot 6/2',		LTRIM('19901201'),		111,	4,		2600200.90,		1,		1001,		'Bungalow',			1	),
	('Kanayim 98',		LTRIM('19520101'),		98,		3,		3500500.01,		1,		1002,		'Apartment',		3	),
	('Dizingoff 30/10',	LTRIM('19891020'),		100,	4,		1250000.11,		1,		1003,		'Villa',			2	),
	('Reut 18/1',		LTRIM('19901210'),		102,	4,		1550000.01,		0,		1004,		'Villa',			5	),
	('Macabi 11',		LTRIM('19781020'),		309,	8,		2901000.99,		1,		1005,		'Villa',			11	),
	('Neurim 10',		LTRIM('20101011'),		45,		2,		1010230.01,		0,		1006,		'Townhome',			8	),
	('Biet-Yofi 17/1',	LTRIM('20120701'),		67,		3,		2150500.31,		1,		1007,		'Single-Family',	8	),
	('Leonardo 28',		LTRIM('19990623'),		121,	5,		1350000.01,		0,		1008,		'Single-Family',	2	),
	('Neurim 11',		LTRIM('19970315'),		205,	6,		1760100.21,		1,		1009,		'Ranch',			11	),
	('Silabus 30',		LTRIM('20010510'),		151,	5,		1800100.41,		1,		1010,		'In-Law Suite',		5	),
	('Sella-col 14',	LTRIM('20160328'),		87,		3,		2110000.81,		1,		1011,		'Cottage',			4	),
	('Maon 81/4',		LTRIM('19990106'),		99,		4,		1530200.21,		0,		1012,		'Bungalow',			2	),
	('Gamers 16',		LTRIM('20060719'),		165,	6,		1430010.71,		1,		1013,		'Carriage / Coach',	10	),
	('Lepo-Lesham 101',	LTRIM('19951218'),		260,	7,		1630010.31,		1,		1014,		'Carriage / Coach',	3	),
	('Million 320',		LTRIM('20030313'),		310,	7,		2601000.72,		1,		1015,		'Carriage / Coach',	7	),
	('Manzur 101',		LTRIM('20110220'),		105,	5,		1204100.11,		0,		1016,		'Carriage / Coach',	9	),
	('Dom 8',			LTRIM('19981130'),		104,	4,		1187220.71,		1,		1017,		'Carriage / Coach',	9	),
	('Razo 11/1',		LTRIM('20170821'),		172,	5,		1300000.71,		1,		1001,		'Cottage',			9	),
	('Dom 11',			LTRIM('20150821'),		112,	4,		1700000.81,		1,		1006,		'In-Law Suite',		2	),
	('Dom 12',			LTRIM('20150821'),		200,	6,		2200300.11,		1,		1011,		'In-Law Suite',		3	)

CREATE TABLE [Sales] (
	SaleID INT PRIMARY KEY IDENTITY (1, 1),
	HouseID INT FOREIGN KEY REFERENCES [Houses] (HouseID) NOT NULL,
	BuyerID INT FOREIGN KEY REFERENCES [People] (PersonID) NULL,
	SellerID INT FOREIGN KEY REFERENCES [People] (PersonID) NOT NULL,
		CONSTRAINT CHK_Seller
			CHECK (SellerID != BuyerID),
	SalesManID INT FOREIGN KEY REFERENCES [SalesMen] (SalesManID) NOT NULL,
	[Final Price] money CONSTRAINT [DF_Sale_Details_Price] NULL,
		CONSTRAINT CHK_Price	
			CHECK ([Final Price] > 50000),
	Income real CONSTRAINT [DF_Sale_Details_Discount] DEFAULT (0.05) NOT NULL 
		CONSTRAINT CHK_Discount	
			CHECK (Income >= 0 AND (Income <= 1)),
	[Sale date] datetime NULL
		CONSTRAINT CHK_Sale_Date
			CHECK ([Sale date] <= GETDATE() AND [Sale date] > '19991230'),
	[Publish Date] datetime NOT NULL
			CHECK ([Publish Date] <= GETDATE() AND [Publish Date] > '19991230'),
	UNIQUE (SaleID)
);
INSERT INTO Sales VALUES 
--	HouseID,	BuyerID,	SellerID	SaleManID,	FNL-Price,		Income(%),	 Sale date		 PublishDate	
	(1,			1000,		1017,		90000,		1500000.00,		0.10,		('20220502'),	('20200611')),
	(2,			1001,		1015,		90000,		2550200.90,		0.08,		('20190313'),	('20171204')),
	(3,			1002,		1013,		90002,		3200500.01,		0.07,		('20190821'),	('20180214')),
	(4,			1003,		1011,		90001,		1250000.00,		0.07,		('20220108'),	('20210709')),
	(5,			1004,		1009,		90001,		1565000.01,		0.10,		('20220406'),	('20190919')),
	(6,			1005,		1007,		90001,		2821000.99,		0.11,		('20201103'),	('20190102')),
	(7,			1006,		1005,		90014,		1210230.01,		0.12,		('20201219'),	('20180725')),
	(8,			1007,		1003,		90008,		2100000.31,		0.09,		('20211014'),	('20200530')),
	(9,			1008,		1001,		90009,		1290000.01,		0.05,		('20190201'),	('20181102')),
   (10,			1009,		1000,		90010,		1770100.00,		0.10,		('20220715'),	('20210203')),
   (11,			1010,		1002,		90005,		1600100.41,		0.12,		('20210920'),	('20200606')),
   (12,			1011,		1004,		90003,		2100000.11,		0.06,		('20200130'),	('20190417')),
   (13,			1012,		1006,		90000,		1530200.21,		0.08,		('20200126'),	('20181203')),
   (14,			1013,		1008,		90011,		1400010.71,		0.15,		('20190126'),	('20170530')),
   (15,			1014,		1010,		90012,		1550010.31,		0.13,		('20220311'),	('20200908')),
   (16,			1015,		1012,		90017,		2301000.72,		0.09,		('20190417'),	('20181212')),
   (17,			1016,		1014,		90018,		1150100.11,		0.06,		('20201229'),	('20190801')),
   (18,			1017,		1015,		90018,		1157220.71,		0.08,		('20211122'),	('20200918')),
   (19,			NULL,		1001,		90003,		NULL,			0.06,		NULL		,	('20171122')),
   (20,			NULL,		1006,		90005,		NULL,			0.07,		NULL		,	('20190802')),
   (21,			NULL,		1011,		90015,		NULL,			0.10,		NULL		,	('20180105'))

-- QUERIES
-- A
-- חשב את רווחי החברה מכל התיווכים שנעשו השנה לפי סוג הבית. רווח מחושב ע"י ההפרש
-- בין מחיר המכירה של החברה ללקוח לבין המחיר אותו ביקש הלקוח שמוכר את ביתו. יש 
-- להציג לכל סוג בית )לדוגמא: דירה בבנין, פנטהאוז וכדומה( את סה"כ הרווחים השנה.
SELECT H.TypeID AS [House Type],
	SUM([Final Price] * Income + ([Final Price] - [Wanted Price])) AS [Yearly Income]
FROM Houses H INNER JOIN Sales S 
	ON S.HouseID = H.HouseID 
WHERE YEAR([Sale date]) = YEAR(GETDATE())
GROUP BY H.TypeID
	HAVING SUM([Final Price] * Income + ([Final Price] - [Wanted Price])) > 0

-- B
-- הצג לקוחות אשר מכרו באמצעות שירותי החברה וקנו בית אחר במחיר הגבוה ממחיר
-- המכירה.
-- ALL SALES 
SELECT P.PersonID,P.[First Name],P.[Last Name],P.[Phone Number], S.SaleID,H.TypeID AS [House Type],
	RTRIM(H.[Built At]) AS [Build At],C.CityName AS City,N.Name AS Neighborhood,H.Rooms,
	H.[Size (M^2)],H.[Wanted Price],S.[Final Price],(S.[Final Price] - H.[Wanted Price])'DIFF'
FROM Sales S INNER JOIN 
					(SELECT S.SellerID, P.[First Name],P.[Last Name],P.[Phone Number],P.CompanyID
						FROM Sales S INNER JOIN People P ON P.PersonID = S.SellerID
						WHERE S.SellerID IS NOT NULL AND S.SalesManID IS NOT NULL) AS SELLERS
	ON S.BuyerID = SELLERS.SellerID INNER JOIN Houses H ON H.HouseID = S.HouseID 
	INNER JOIN People P ON P.PersonID = S.BuyerID INNER JOIN Neighborhoods N
	ON N.NeighborhoodID = H.NeighborhoodID INNER JOIN Cities C ON C.CityId = N.CityId
 WHERE H.[Wanted Price] < S.[Final Price]

-- C
-- מה י השכונה היוקרתית ביותר? הצגו את שם השכונה ושם העיר אשר ממוצע מחירי הבתים
-- שנמכרו בה הכי יקרים.
GO
	CREATE VIEW V_Neighborhood_TOTAL_Price AS (
		SELECT C.CityName, N.[Name] AS Neighborhood, 
			SUM(H.[Wanted Price]) AS [Total Wanted]
			--,SUM(S.[Final Price]) AS [Total Final Price]
		FROM Sales S INNER JOIN Houses H ON S.HouseID = H.HouseID
			 INNER JOIN Neighborhoods N  ON N.NeighborhoodID = H.NeighborhoodID
			 INNER JOIN Cities C		 ON C.CityId = N.CityId
		GROUP BY C.CityName, N.[Name])
GO 

SELECT TOP 1 * -- By removing the TOP 1, Will see all Neighborhoods and their total VALUE
FROM V_Neighborhood_TOTAL_Price V ORDER BY V.[Total Wanted] DESC

-- D
-- הצג את העובד המצטיין לכל שנה. עובד מצטיין הינו עובד שסך הרווחים ממכירותיו הכי גבוהה באותה שנה.
GO
	CREATE VIEW V_EXCELLENT_WORKER AS (
		SELECT YEAR(S.[Sale Date]) AS [Year], S.SalesManID,
			CASE
				WHEN H.[Wanted Price] >= S.[Final Price] THEN MAX(S.[Final Price] * Income)
				ELSE MAX(S.[Final Price] * Income + (S.[Final Price] - H.[Wanted Price]))
			END AS [Total Income]
		FROM Sales S INNER JOIN Houses H ON H.HouseID = S.HouseID
		GROUP BY YEAR(S.[Sale date]), S.SalesManID, H.[Wanted Price], S.[Final Price])
GO

SELECT DISTINCT V.[Year], MAX(v.[Total Income]) AS [Max Income],
	S.[First Name], S.[Last Name], S.SalesManID
FROM SalesMen S INNER JOIN V_EXCELLENT_WORKER V ON S.SalesManID = V.SalesManID 
				INNER JOIN Specialization SP	ON S.SalesManID = SP.SalesManID 
GROUP BY v.[Year], S.[First Name], S.[Last Name], S.SalesManID, S.CompanyID
	HAVING MAX(V.[Total Income]) in (SELECT MAX([Total Income]) FROM V_EXCELLENT_WORKER GROUP by [Year])
ORDER BY [Year] DESC

-- E
-- הציעו בית חדש ומרווח יותר ללקוח שרכש בית באמצעות שירותי החברה לפני שנתיים או
-- יותר באותה עיר שבה גר. )מרווח יותר משמעו מספר חדרים גדול יותר או שטח גדול יותר(
-- שימו לב כי הבית המוצע חייב להיות בית למכירה ברגע זה ואינו בית שכבר נמכר.
GO
	CREATE VIEW V_CUSTOMERS_2YEARS_EXPIRY AS (
		SELECT P.PersonID, (P.[First Name] + ' ' + P.[Last Name]) AS [Full Name], N.CityId, 
				-- Possibly the owner has several occupancies in different locations so we offer him 
				P.[Phone Number], MAX(LTRIM(S.[Sale date])) AS [Sale Date]
		FROM People P JOIN Sales S  ON P.PersonID = S.BuyerID JOIN Houses H ON H.HouseID = S.HouseID
			INNER JOIN Neighborhoods N ON N.NeighborhoodID = H.NeighborhoodID INNER JOIN Cities C ON C.CityId = N.CityId
		GROUP BY P.PersonID, (P.[First Name] + ' ' + P.[Last Name]) , P.[Phone Number], N.CityId
			HAVING DATEDIFF(DAY,MAX(LTRIM(S.[Sale date])),GETDATE()) / 365.0 >= 2)
GO
GO
	CREATE VIEW V_AVAILABLE_HOUSES AS (
	SELECT H.HouseID AS [For sale HouseID], [Address], LTRIM([Built At]) AS [Built At], [Size (M^2)],
		Rooms, [Wanted Price], OwnerID AS HouseOwnerID, TypeID, N.NeighborhoodID AS NeighborID,N.[Name] AS Neighbor, N.CityId AS SameCityID
	FROM Houses H INNER JOIN Sales S ON H.HouseID = S.HouseID INNER JOIN Neighborhoods N ON N.NeighborhoodID = H.NeighborhoodID
	WHERE H.[For Sale] <> 0 OR S.[Sale date] IS NULL/**/)
		-- If COMMENT the 'WHERE [For Sale] <> 0' you will also get the not for sale Houses
GO
-- This query suggests a house with conditions foreach customer that bought a house before 2 years ago and at the same city
SELECT P.PersonID,(P.[First Name] + ' ' + P.[Last Name])'Full Name', P.[Phone Number],
	/*Onwners Current house*/ H.HouseID AS [Current HouseID], H.TypeID, H.Rooms AS [Current Rooms], H.[Size (M^2)]  AS [Current Size (M^2)], LTRIM(H.[Built At]) AS [Current Built At], N.[Name] AS Neighbor,
	/*Matching House*/ V2.*
FROM V_CUSTOMERS_2YEARS_EXPIRY V1 INNER JOIN People P 
	ON	P.PersonID = V1.PersonID INNER JOIN Sales S 
	ON S.BuyerID = P.PersonID AND S.[Sale date] = V1.[Sale Date] INNER JOIN Houses H 
	ON H.HouseID = S.HouseID LEFT OUTER JOIN V_AVAILABLE_HOUSES V2
	ON (H.Rooms < V2.Rooms OR H.[Size (M^2)] < V2.[Size (M^2)]/* OR V2.[Built At] > H.[Built At]*/) INNER JOIN Neighborhoods N
	ON N.NeighborhoodID = H.NeighborhoodID
WHERE V1.PersonID != V2.HouseOwnerID AND V2.SameCityID = N.CityId AND [Full Name] LIKE '%%' -- Specific Customers name between the two Percentages signs
ORDER BY PersonID