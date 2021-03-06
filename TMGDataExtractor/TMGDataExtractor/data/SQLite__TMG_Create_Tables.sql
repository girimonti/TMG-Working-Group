-- Describe TIMELINELOCK
CREATE TABLE "TimelineLock" (
    "IDLOCK" INTEGER(4),
    "TNAME" CHAR(50),
    "DSID" INTEGER(4),
    "TT" CHAR(1),
    "TimelineLock_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe DNA
CREATE TABLE "DNA" (
    "DSID" INTEGER(4),
    "ID_DNA" INTEGER PRIMARY KEY NOT NULL,
    "ID_PERSON" INTEGER(4),
    "DNANAME" CHAR(100),
    "COMMENTS" VARCHAR,
    "DESCRIPT" VARCHAR,
    "RESULT" VARCHAR,
    "URL" VARCHAR,
    "LOGO" VARCHAR,
    "TT" CHAR(1),
    "KITNUMBER" CHAR(24),
    "TYPE" CHAR(1),
    "NAMEREC" INTEGER(4)
)

-- Describe EVENT
CREATE TABLE "Event" (
    "ETYPE" INTEGER(4),
    "DSID" INTEGER(4),
    "PER1SHOW" BOOLEAN,
    "PER2SHOW" BOOLEAN,
    "PER1" INTEGER(4),
    "PER2" INTEGER(4),
    "EDATE" CHAR(30),
    "PLACENUM" INTEGER(4),
    "EFOOT" VARCHAR,
    "ENSURE" CHAR(1),
     "ESSURE" CHAR(1),
     "EDSURE" CHAR(1),
      "EPSURE" CHAR(1),
     "EFSURE" CHAR(1),
     "RECNO" INTEGER PRIMARY KEY NOT NULL,
     "SENTENCE" VARCHAR,
    "SRTDATE" CHAR(30),
    "TT" CHAR(1),
    "REF_ID" INTEGER(4)
)

-- Describe EVENTWITNESS
CREATE TABLE "EventWitness" (
    "EPER" INTEGER(4),
    "GNUM" INTEGER(4),
    "PRIMARY" BOOLEAN,
    "WSENTENCE" VARCHAR,
    "TT" CHAR(1),
    "ROLE" CHAR(5),
    "DSID" INTEGER(4),
    "NAMEREC" INTEGER(4),
    "WITMEMO" VARCHAR,
    "SEQUENCE" INTEGER(4),
    "EventWitness_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe EXHIBIT
CREATE TABLE "Exhibit" (
    "IDEXHIBIT" INTEGER PRIMARY KEY NOT NULL,
    "IDREF" INTEGER(4),
    "RLTYPE" CHAR(1),
    "RLNUM" INTEGER(4),
    "XNAME" CHAR(30),
    "VFILENAME" VARCHAR,
    "IFILENAME" VARCHAR,
    "AFILENAME" VARCHAR,
    "TFILENAME" VARCHAR,
    "REFERENCE" CHAR(25),
     "TEXT" VARCHAR,
     "IMAGE" BLOB,
      "AUDIO" BLOB,
     "DESCRIPT" VARCHAR,
     "RLPER1" INTEGER(4),
     "RLPER2" INTEGER(4),
    "RLGTYPE" INTEGER(4),
    "OLE_OBJECT" BLOB,
    "PRIMARY" BOOLEAN,
        "VIDEO" BLOB,
    "PROPERTY" VARCHAR,
    "DSID" INTEGER(4),
    "TT" CHAR(1),
    "ID_PERSON" INTEGER(4),
    "ID_EVENT" INTEGER(4),
    "ID_SOURCE" INTEGER(4),
    "ID_REPOS" INTEGER(4),
    "THUMB" BLOB,
    "ID_CIT" INTEGER(4),
     "ID_PLACE" INTEGER(4),
     "CAPTION" VARCHAR,
      "SORTEXH" INTEGER(4),
     "IMAGEFORE" BLOB,
     "IMAGEBACK" BLOB,
     "TRANSPAR" NUMERIC
)

-- Describe FLAG
CREATE TABLE "Flag" (
    "FLAGLABEL" CHAR(50),
    "FLAGFIELD" CHAR(10),
    "FLAGVALUE" CHAR(250),
    "SEQUENCE" INTEGER,
    "DESCRIPT" VARCHAR,
    "ACTIVE" BOOLEAN,
    "FLAGID" INTEGER PRIMARY KEY NOT NULL,
    "PROPERTY" VARCHAR,
    "DSID" INTEGER NOT NULL,
    "TT" CHAR(1)
)

-- Describe FOCUSGROUP
CREATE TABLE "FocusGroup" (
     "GROUPNUM" INTEGER PRIMARY KEY autoincrement NOT NULL,
     "GROUPNAME" CHAR(40),
     "RECENT" BOOLEAN,
     "TT" CHAR(1)
)

-- Describe FOCUSGROUPMEMBER
CREATE TABLE "FocusGroupMember" (
    "GROUPNUM" INTEGER(4),
    "MEMBERNUM" INTEGER(4),
    "TT" char(1),
    "DSID" INTEGER(4),
    "FocusGroupMember_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe NAME
CREATE TABLE person (
    "PER_NO" INTEGER PRIMARY KEY NOT NULL,
    "FATHER" INTEGER,
    "MOTHER" INTEGER,
    "LAST_EDIT" DATETIME NOT NULL,
    "DSID" INTEGER NOT NULL,
    "REF_ID" INTEGER,
    "REFERENCE" VARCHAR(12),
    "SPOULAST" INTEGER,
    "SCBUFF" VARCHAR(10),
    "PBIRTH" VARCHAR(30),
    "PDEATH" VARCHAR(30),
    "SEX" CHAR(1) NOT NULL,
    "LIVING" CHAR(1) NOT NULL,
    "BIRTHORDER" CHAR(2) NOT NULL,
    "MULTIBIRTH" CHAR(1) NOT NULL,
    "ADOPTED" CHAR(1) NOT NULL,
    "ANCE_INT" CHAR(1) NOT NULL,
    "DESC_INT" CHAR(1) NOT NULL,
    "RELATE" INTEGER,
    "RELATEFO" INTEGER,
    "TT" CHAR(1),
    "FLAG1" CHAR(1)
)

-- Describe NAMEDICTIONARY
CREATE TABLE "NameDictionary" (
     "UID" INTEGER(4),
      "VALUE" VARCHAR,
     "SDX" CHAR(4),
     "TT" CHAR(1),
     "NameDictionary_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe NAMEPARTTYPE
CREATE TABLE "NamePartType" (
     "ID" INTEGER(4),
     "VALUE" CHAR(100),
     "SYSTEM" BOOLEAN,
     "TYPE" INTEGER(4),
     "SHORTVALUE" CHAR(20),
     "TT" CHAR(1),
     "DSID" INTEGER(4),
     "TEMPLATE" CHAR(30),
     "NamePartType_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe NAMEPARTTYPE
CREATE TABLE "NamePartType" (
     "ID" INTEGER(4),
     "VALUE" CHAR(100),
     "SYSTEM" BOOLEAN,
     "TYPE" INTEGER(4),
     "SHORTVALUE" CHAR(20),
     "TT" CHAR(1),
     "DSID" INTEGER(4),
     "TEMPLATE" CHAR(30),
     "NamePartType_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe NAMEPARTVALUE
CREATE TABLE "NamePartValue" (
     "RECNO" INTEGER(4),
     "UID" INTEGER(4),
     "TYPE" INTEGER(4),
     "ID" INTEGER(4),
     "TT" CHAR(1),
     "DSID" INTEGER(4),
     "NamePartValue_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)
-- Describe PARENTCHILDRELATIONSHIP
CREATE TABLE "ParentChildRelationship" (
    "PRIMARY" BOOLEAN,
    "CHILD" INTEGER(4),
    "PARENT" INTEGER(4),
    "PTYPE" INTEGER(4),
    "PNOTE" VARCHAR,
    "PSURE" CHAR(1),
    "FSURE" CHAR(1),
    "RECNO" INTEGER PRIMARY KEY NOT NULL,
    "TT" CHAR(1),
    "DSID" INTEGER(4)
)

-- Describe PERSON
CREATE TABLE person (
    "PER_NO" INTEGER PRIMARY KEY NOT NULL,
    "FATHER" INTEGER,
    "MOTHER" INTEGER,
    "LAST_EDIT" DATETIME NOT NULL,
    "DSID" INTEGER NOT NULL,
    "REF_ID" INTEGER,
    "REFERENCE" VARCHAR(12),
    "SPOULAST" INTEGER,
    "SCBUFF" VARCHAR(10),
    "PBIRTH" VARCHAR(30),
    "PDEATH" VARCHAR(30),
    "SEX" CHAR(1) NOT NULL,
    "LIVING" CHAR(1) NOT NULL,
    "BIRTHORDER" CHAR(2) NOT NULL,
    "MULTIBIRTH" CHAR(1) NOT NULL,
    "ADOPTED" CHAR(1) NOT NULL,
    "ANCE_INT" CHAR(1) NOT NULL,
    "DESC_INT" CHAR(1) NOT NULL,
    "RELATE" INTEGER,
    "RELATEFO" INTEGER,
    "TT" CHAR(1),
    "FLAG1" CHAR(1)
)

-- Describe PLACEDICTIONARY
CREATE TABLE "PlaceDictionary" (
     "UID" INTEGER(4),
      "VALUE" VARCHAR,
     "SDX" CHAR(4),
     "TT" CHAR(1),
     "PlaceDictionary_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe PLACEFILE
CREATE TABLE "PlaceFile" (
     "RECNO" INTEGER PRIMARY KEY NOT NULL,
     "STYLEID" INTEGER(4),
     "DSID" INTEGER(4),
     "TT" CHAR(1),
     "STARTYEAR" CHAR(4),
     "ENDYEAR" CHAR(4),
     "COMMENT" VARCHAR,
     "SHORTPLACE" VARCHAR
)

-- Describe PLACEPARTTYPE
CREATE TABLE "PlacePartType" (
     "ID" INTEGER(4),
     "TYPE" INTEGER(4),
     "VALUE" CHAR(100),
     "SYSTEM" BOOLEAN,
     "SHORTVALUE" CHAR(20),
     "TT" CHAR(1),
     "DSID" INTEGER(4),
     "PlacePartType_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe PLACEPARTVALUE
CREATE TABLE "PlacePartValue" (
     "RECNO" INTEGER(4),
     "UID" INTEGER(4),
     "TYPE" INTEGER(4),
     "ID" INTEGER(4),
     "TT" CHAR(1),
     "DSID" INTEGER(4),
     "PlacePartValue_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe REPOSITORY
CREATE TABLE "Repository" (
     "DSID" INTEGER(4),
     "NAME" VARCHAR,
     "RECNO" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
     "REF_ID" INTEGER(4),
     "ABBREV" CHAR(50),
     "ADDRESS" INTEGER(4),
     "RNOTE" VARCHAR,
     "RPERNO" INTEGER(4),
     "ISPICKED" BOOLEAN,
     "TT" CHAR(1)
)

-- Describe RESEARCHLOG
CREATE TABLE "ResearchLog" (
    "RLTYPE" CHAR(1),
    "RLNUM" INTEGER(4) ,
    "RLPER1" INTEGER(4),
    "RLPER2" INTEGER(4),
    "RLGTYPE" INTEGER(4),
    "TASK" VARCHAR,
    "RLEDITED" CHAR(11),
    "DESIGNED" CHAR(11),
    "BEGUN" CHAR(11),
    "PROGRESS" CHAR(11),
    "COMPLETED" CHAR(11),
    "PLANNED" CHAR(11),
    "EXPENSES" NUMERIC(14,2),
    "COMMENTS" VARCHAR,
    "RLNOTE" VARCHAR,
    "KEYWORDS" VARCHAR,
    "DSID" INTEGER(4),
    "ID_PERSON" INTEGER(4),
    "ID_EVENT" INTEGER(4),
    "ID_SOURCE" INTEGER(4),
    "ID_REPOS" INTEGER(4),
    "TT" CHAR(1),
    "REFERENCE" CHAR(30),
    "ResearchLog_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe SOURCE
CREATE TABLE "Source" (
    "MACTIVE" BOOLEAN,
    "MAJNUM" INTEGER PRIMARY KEY NOT NULL,
    "REF_ID" INTEGER(4),
    "ABBREV" CHAR(50),
    "DEFSURE" CHAR(1),
    "TITLE" VARCHAR,
    "TYPE" NUMERIC(3),
    "RECORDER" NUMERIC(2),
    "MEDIA" NUMERIC(2),
    "FIDELITY" NUMERIC(2),
    "INDEXED" NUMERIC(1),
    "STATUS" NUMERIC(2),
    "TEXT" VARCHAR,
    "SPERNO" INTEGER(4),
    "ISPICKED" BOOLEAN,
    "INFO" VARCHAR,
    "FFORM" VARCHAR,
    "SFORM" VARCHAR,
    "BFORM" VARCHAR,
    "CITED" BOOLEAN,
    "IBIDTYPE" NUMERIC(1),
    "SUBJECTID" INTEGER(4),
    "COMPILERID" INTEGER(4),
    "EDITORID" INTEGER(4),
    "SPERNO2" INTEGER(4),
    "UNCITEDFLD" VARCHAR,
    "CUSTTYPE" INTEGER(4),
    "FIRSTCD" VARCHAR,
    "DSID" INTEGER(4),
    "REMINDERS" VARCHAR,
     "TT" CHAR(1)
)

-- Describe SOURCECITATION
CREATE TABLE "SourceCitation" (
    "RECNO" 	INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    "STYPE" 	CHAR(1),
    "REFREC" 	INTEGER(4),
    "MAJSOURCE" INTEGER(4),
    "SUBSOURCE" VARCHAR,
    "SNSURE" 	CHAR(1),
    "SSSURE" 	CHAR(1),
    "SDSURE" 	CHAR(1),
    "SPSURE" 	CHAR(1),
    "SFSURE" 	CHAR(1),
    "ISPICKED" 	BOOLEAN,
    "SEQUENCE" 	INTEGER(4),
    "CITMEMO" 	VARCHAR,
    "EXCLUDE" 	BOOLEAN,
    "TT" 	CHAR(1),
    "DSID" 	INTEGER(4),
    "CITREF" 	CHAR(30)
)

-- Describe SOURCETYPE
CREATE TABLE sourcetype (
    "RULESET" NUMERIC(1),
    "DSID" INTEGER(4) DEFAULT (1),
    "SOURTYPE" INTEGER(4),
    "TRANS_TO" INTEGER(4),
    "NAME" CHAR(66),
    "FOOT" VARCHAR,
    "SHORT" VARCHAR,
    "BIB" VARCHAR,
    "CUSTFOOT" VARCHAR,
    "CUSTSHORT" VARCHAR,
    "CUSTBIB" VARCHAR,
    "SAMEAS" INTEGER(4),
    "SAMEASMSG" VARCHAR,
    "PRIMARY" BOOLEAN,
    "REMINDERS" VARCHAR,
    "TT" CHAR(1),
    "SourceType_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)

-- Describe STYLE
CREATE TABLE "Style" (
    "STYLEID" 		INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    "ST_DISPLAY" 	VARCHAR,
    "ST_OUTPUT" 	VARCHAR,
    "GROUP" 		CHAR(1),
    "SRNAMESORT" 	VARCHAR,
    "SRNAMEDISP" 	VARCHAR,
    "GVNAMESORT" 	VARCHAR,
    "GVNAMEDISP" 	VARCHAR,
    "OTHERDISP" 	VARCHAR,
    "TT" 		CHAR(1),
    "DSID" 		INTEGER(4),
    "STYLENAME" 	CHAR(100)
)

-- Describe TAGTYPE
CREATE TABLE "TagType" (
    ISPICKED 		BOOLEAN,
    DSID 		INTEGER(4),
    "ACTIVE" 		BOOLEAN,
    "ETYPENUM" 		INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    "ORIGETYPE" 	INTEGER(4),
    "ADMIN" 		NUMERIC(2),
    "LDSONLY" 		BOOLEAN,
    "ETYPENAME" 	CHAR(20),
    "GEDCOM_TAG"	CHAR(4),
    "ISREPORT" 		BOOLEAN,
    "TSENTENCE" 	VARCHAR,
    "ABBREV" 		CHAR(4),
    "WITDISP" 		BOOLEAN,
    "PASTTENSE" 	CHAR(20),
    "PRINROLE" 		BOOLEAN,
    "WITROLE" 		BOOLEAN,
    "MAXYEAR" 		NUMERIC(4),
    "MINYEAR" 		NUMERIC(4),
    "REMINDERS" 	VARCHAR,
    "TT" 		CHAR(1),
    "PROPERTIES" 	VARCHAR
)

-- Describe TIMELINELOCK
CREATE TABLE "TimelineLock" (
    "IDLOCK" INTEGER(4),
    "TNAME" CHAR(50),
    "DSID" INTEGER(4),
    "TT" CHAR(1),
    "TimelineLock_ID" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
)
