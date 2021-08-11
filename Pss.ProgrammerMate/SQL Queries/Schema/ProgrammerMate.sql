--drop table Projects

Create Table Methodology
(
	ID int not null primary key identity(1,1),
	Name nvarchar(100) not null unique,
	PDescription nvarchar(1000),
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

Create Table MethodologyStructure
(
	ID int not null primary key identity(1,1),
	MethodologyID int foreign key references Methodology(ID),
	StructureName nvarchar(100) not null,
	SDescription nvarchar(1000),
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

Create Table Solutions
(
	ID int not null primary key identity(1,1),
	SolutionName nvarchar(100) not null unique,
	SNameSpace nvarchar(200) not null,
	SDescription nvarchar(1000),
	Methodology nvarchar(100) not null,
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

--drop table SolutionsDB
Create Table SolutionsDB
(
	ID int not null primary key identity(1,1),
	SolutionID int not null foreign key references Solutions(Id) On Delete Cascade,
	DBType nvarchar(100) not null,
	ServerName nvarchar(200),
	DBName nvarchar(100),
	UserName nvarchar(100),
	DPassword nvarchar(200),
	SQLType nvarchar(100),
	SPFormat nvarchar(200),
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())

)

Create Table SolutionFolders
(
	ID int not null primary key identity(1,1),
	SolutionID int not null foreign key references Solutions(Id) On Delete Cascade,
	ParentFolderId int default(0),
	FolderName nvarchar(100) not null,
	NamespaceFormat nvarchar(300) not null,
	isCreateFolder bit default('True'),
	FDescription nvarchar(1000),
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

Create Table SolutionsDBTables
(
	ID int not null primary key identity(1,1),
	SolutionsDBID int not null foreign key references SolutionsDB(ID) ,
	TableName nvarchar(200) not null,
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

Create Table SolutionFolders_Tables
(
	ID int not null primary key identity(1,1),
	FolderID int foreign key references SolutionFolders(ID) ,
	TableID int foreign key references SolutionsDBTables(ID) ,
	FolderName nvarchar(200), 
	TableName nvarchar(200) ,
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())


)

--drop table SolutionsDBTableColumns
Create Table SolutionsDBTableColumns
(
	ID int not null primary key identity(1,1),
	SolutionsDBID int not null foreign key references SolutionsDB(ID) ,
	TableId int,
	TableName nvarchar(200) not null,
	ColumnName nvarchar(200) not null,
	ColumnType nvarchar(100),
	ColumnDataType nvarchar(100),
	DataType nvarchar(100),
	COLUMN_KEY nvarchar(100),
	isIdentity bit default('False'),
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

--drop table SolutionsDBQuery
Create Table SolutionsDBQuery
(
	ID int not null primary key identity(1,1),
	SolutionsDBID int not null foreign key references SolutionsDB(ID) ,
	TableName nvarchar(150),
	QueryType nvarchar(100),
	ActionType nvarchar(100),
	QueryName nvarchar(200),
	QueryText Text,
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)
--drop table SolutionsDBQueryColumns
Create Table SolutionsDBQueryColumns
(
	ID int not null primary key identity(1,1),
	SolutionsDBID int not null foreign key references SolutionsDB(ID) ,
	QueryId int ,
	QueryName nvarchar(200),
	TableId int ,
	TableName nvarchar(200) ,
	ColumnName nvarchar(200) not null,
	ColumnType nvarchar(100),
	ColumnDataType nvarchar(100),
	DataType nvarchar(100),
	COLUMN_KEY nvarchar(100),
	isIdentity bit default('False'),
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())

)
 

Create Table Projects
(
	ID int not null primary key identity(1,1),
	SolutionID int not null foreign key references Solutions(Id) On Delete Cascade,
	ProjectType nvarchar(100) not null,
	ProjectName nvarchar(100) not null ,
	PNameSpace nvarchar(100) not null,
	PDescription nvarchar(1000),
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

Alter Table Projects add isReturnObject bit ;
Alter Table Projects add MethodNamingFormat nvarchar(300) ;
Alter Table Projects add BaseFolder nvarchar(500) ;

--drop table ProjectFolders
Create Table ProjectFolders
(
	ID int not null primary key identity(1,1),
	ProjectId int not null foreign key references Projects(Id) on Delete Cascade,
	ParentFolderId int default(0),
	FolderName nvarchar(100) not null,
	FNameSpace nvarchar(300) not null,
	isCreateFolder bit default('True'),
	FDescription nvarchar(1000),
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

--drop table ProjectMethods
Create Table ProjectMethods
(
	ID int not null primary key identity(1,1),
	ProjectId int not null foreign key references Projects(Id) on Delete Cascade,
	ActionType nvarchar(100),
	MethodName nvarchar(100),
	MethodFormat nvarchar(100),
	MDescription nvarchar(1000),
	AllowSummary bit default('False'),
	SummaryFormat nvarchar(1000),
	SqlQueryName nvarchar(300),
	SqlQueryType nvarchar(100),
	ReturnType nvarchar(200),
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
)

Create Table ProjectFiles
(
	ID int not null primary key identity(1,1),
	ProjectId int not null foreign key references Projects(Id) on Delete Cascade,
	FolderId int default(0),
	FolderName nvarchar(100),
	FNameSpace nvarchar(200),
	SaveAs nvarchar(100),
	FullPath nvarchar(500),
	FileData Text,
	UserId int,
	isActive bit default('False'),
	CreatedOnUtc DateTime default(getDate()),
	UpdatedOnUtc DateTime default(getDate())
);

Alter Table ProjectFiles add ClassType nvarchar(100);
Alter Table ProjectFiles add isGenerated bit ;



GO


create function [dbo].[ps_getNormalWord](@myText nvarchar(400))
Returns nvarchar(400)
As
BEGIN
/*declare @myText nvarchar(400) = 'PackageId'*/
declare @Loop int = 0;
declare @Start int  =1;
declare @ReturnString nvarchar(200) =''
declare @isUpper bit = 'false'
declare @FirstString nvarchar(2)
set @loop = len(@myText)

	While @Start<=@Loop
	Begin
		if substring(@myText,@start,1) = UPPER(substring(@myText,@start,1)) Collate SQL_Latin1_General_CP1_CS_AS
		begin
			/*print substring(@myText,@start,1) + 'Yes'			*/
			set @FirstString = ' ' + Upper(substring(@myText,@start,1))
			set @isUpper='true';			
		end
		else
		begin
			set @isUpper='false';
		end
		
		if @isUpper='true'
		begin
			set @ReturnString = @ReturnString + @FirstString
		end
		else
		begin
			set @ReturnString = @ReturnString + substring(@myText,@start,1)
		end
		
		set @Start =@Start +1
	End
	
	return isnull(ltrim(@ReturnString),'')
end
