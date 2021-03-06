USE [ProgrammerMate]
GO
/****** Object:  StoredProcedure [dbo].[sp_Methodology_GetList]    Script Date: 12/9/2015 8:11:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Name: sp_Methodology_GetList
Created By: Pss Programmer Mate
Author: Sajjucode
Created At: Sat, Nov 21,2015 22:21:06
Updated At: Sat, Nov 21,2015 22:21:06
Description : Get List
*/


 CREATE procedure [dbo].[sp_Methodology_GetList] (
   @org_ID int
 ,    @PageSize int
 ,    @PageNo int
 ,    @OrderType int

) 
 AS 
 Begin 
  If (@OrderType like 'asc') 
  Begin 
     Select ID , Name , PDescription , UserId , isActive,
                CreatedOnUtc , UpdatedOnUtc
     From       Methodology 
     Where (@org_ID = 0 Or ID = @org_ID) 
     Order by ID asc
     OFFSET @PageSize * (@PageNo - 1) ROWS 
     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); 
  End 
Else 
Begin 
     Select ID , Name , PDescription , UserId , isActive,
                CreatedOnUtc , UpdatedOnUtc
     From       Methodology 
     Where (@org_ID = 0 Or ID = @org_ID) 
     Order by ID desc
     OFFSET @PageSize * (@PageNo - 1) ROWS 
     FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); 
End 
End 
GO
/****** Object:  StoredProcedure [dbo].[sp_Methodology_Insert6]    Script Date: 12/9/2015 8:11:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ======================================================
-- Name: sp_Methodology_Insert6
-- Created By: Pss Programmer Mate
-- Author: Sajjucode
-- Created At: Sun, Nov 15,2015 01:17:43
-- Updated At: Sun, Nov 15,2015 01:17:43
-- Description : Insert
-- ======================================================


 Create procedure [dbo].[sp_Methodology_Insert6] (
   @Name nvarchar(100) , 
   @PDescription nvarchar(1000) , 
   @UserId int , 
   @isActive bit , 
   @CreatedOnUtc datetime , 
   @UpdatedOnUtc datetime
) 
AS 
 Begin 


     SET NOCOUNT ON; 
     Insert into Methodology
         ( 
              PDescription , UserId , isActive , CreatedOnUtc,
                UpdatedOnUtc
           )
         Values 
         ( 
               @PDescription , @UserId , @isActive , @CreatedOnUtc,
               @UpdatedOnUtc
         ); 
      Select @@Identity;
 END 

GO
/****** Object:  StoredProcedure [dbo].[sp_Methodology_Update]    Script Date: 12/9/2015 8:11:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Name: sp_Methodology_Update
Created By: Pss Programmer Mate
Author: Sajjucode
Created At: Sun, Nov 15,2015 01:27:08
Updated At: Sun, Nov 15,2015 01:27:08
Description : Update
*/


 Create procedure [dbo].[sp_Methodology_Update] (
   @org_ID int , 
   @Name nvarchar(100) , 
   @PDescription nvarchar(1000) , 
   @UserId int , 
   @isActive bit , 
   @CreatedOnUtc datetime , 
   @UpdatedOnUtc datetime
) 
 AS 
 Begin 
     Update Methodology
     Set       Name=@Name , PDescription=@PDescription , UserId=@UserId , isActive=@isActive,
                CreatedOnUtc=@CreatedOnUtc , UpdatedOnUtc=@UpdatedOnUtc 
     Where ID = @org_ID ;
      select 1 as ReturnValue; 
 END 

GO
/****** Object:  UserDefinedFunction [dbo].[ps_getNormalWord]    Script Date: 12/9/2015 8:11:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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

GO
/****** Object:  Table [dbo].[Methodology]    Script Date: 12/9/2015 8:11:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Methodology](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PDescription] [nvarchar](1000) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MethodologyStructure]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MethodologyStructure](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MethodologyID] [int] NULL,
	[StructureName] [nvarchar](100) NOT NULL,
	[SDescription] [nvarchar](1000) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectFiles]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[FolderId] [int] NULL DEFAULT ((0)),
	[FolderName] [nvarchar](100) NULL,
	[FNameSpace] [nvarchar](200) NULL,
	[SaveAs] [nvarchar](100) NULL,
	[FullPath] [nvarchar](500) NULL,
	[FileData] [text] NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[ClassType] [nvarchar](100) NULL,
	[isGenerated] [bit] NULL,
	[TableName] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectFolders]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFolders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ParentFolderId] [int] NULL,
	[FolderName] [nvarchar](100) NOT NULL,
	[FNameSpace] [nvarchar](300) NOT NULL,
	[isCreateFolder] [bit] NULL,
	[FDescription] [nvarchar](1000) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectMethods]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectMethods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ActionType] [nvarchar](100) NULL,
	[MethodName] [nvarchar](100) NULL,
	[MethodFormat] [nvarchar](100) NULL,
	[MDescription] [nvarchar](1000) NULL,
	[AllowSummary] [bit] NULL,
	[SummaryFormat] [nvarchar](1000) NULL,
	[SqlQueryName] [nvarchar](300) NULL,
	[SqlQueryType] [nvarchar](100) NULL,
	[ReturnType] [nvarchar](200) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionID] [int] NOT NULL,
	[ProjectType] [nvarchar](100) NOT NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
	[PNameSpace] [nvarchar](100) NOT NULL,
	[PDescription] [nvarchar](1000) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[isReturnObject] [bit] NULL,
	[MethodNamingFormat] [nvarchar](300) NULL,
	[BaseFolder] [nvarchar](500) NULL,
	[BusinessEntity_ProjectId] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionFolders]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionFolders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionID] [int] NOT NULL,
	[ParentFolderId] [int] NULL DEFAULT ((0)),
	[FolderName] [nvarchar](100) NOT NULL,
	[NamespaceFormat] [nvarchar](300) NOT NULL,
	[isCreateFolder] [bit] NULL DEFAULT ('True'),
	[FDescription] [nvarchar](1000) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[InterfaceNamespaceFormat] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionFolders_Tables]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionFolders_Tables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FolderID] [int] NULL,
	[TableID] [int] NULL,
	[FolderName] [nvarchar](200) NULL,
	[TableName] [nvarchar](200) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solutions]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solutions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionName] [nvarchar](100) NOT NULL,
	[SNameSpace] [nvarchar](200) NOT NULL,
	[SDescription] [nvarchar](1000) NULL,
	[Methodology] [nvarchar](100) NOT NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SolutionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionsDB]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionsDB](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionID] [int] NOT NULL,
	[DBType] [nvarchar](100) NOT NULL,
	[ServerName] [nvarchar](200) NULL,
	[DBName] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[DPassword] [nvarchar](200) NULL,
	[SQLType] [nvarchar](100) NULL,
	[SPFormat] [nvarchar](200) NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionsDBQuery]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionsDBQuery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionsDBID] [int] NOT NULL,
	[TableName] [nvarchar](150) NULL,
	[QueryType] [nvarchar](100) NULL,
	[ActionType] [nvarchar](100) NULL,
	[QueryName] [nvarchar](200) NULL,
	[QueryText] [text] NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionsDBQueryColumns]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionsDBQueryColumns](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionsDBID] [int] NOT NULL,
	[QueryId] [int] NULL,
	[QueryName] [nvarchar](200) NULL,
	[TableId] [int] NULL,
	[TableName] [nvarchar](200) NULL,
	[ColumnName] [nvarchar](200) NOT NULL,
	[ColumnType] [nvarchar](100) NULL,
	[ColumnDataType] [nvarchar](100) NULL,
	[DataType] [nvarchar](100) NULL,
	[COLUMN_KEY] [nvarchar](100) NULL,
	[isIdentity] [bit] NULL DEFAULT ('False'),
	[AllowNull] [bit] NULL DEFAULT ('True'),
	[ParameterName] [nvarchar](200) NULL,
	[ParameterType] [nvarchar](100) NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionsDBTableColumns]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionsDBTableColumns](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionsDBID] [int] NOT NULL,
	[TableId] [int] NULL,
	[TableName] [nvarchar](200) NOT NULL,
	[ColumnName] [nvarchar](200) NOT NULL,
	[ColumnType] [nvarchar](100) NULL,
	[ColumnDataType] [nvarchar](100) NULL,
	[DataType] [nvarchar](100) NULL,
	[COLUMN_KEY] [nvarchar](100) NULL,
	[isIdentity] [bit] NULL DEFAULT ('False'),
	[AllowNull] [bit] NULL DEFAULT ('True'),
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionsDBTables]    Script Date: 12/9/2015 8:11:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionsDBTables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SolutionsDBID] [int] NOT NULL,
	[TableName] [nvarchar](200) NOT NULL,
	[UserId] [int] NULL,
	[isActive] [bit] NULL DEFAULT ('False'),
	[CreatedOnUtc] [datetime] NULL DEFAULT (getdate()),
	[UpdatedOnUtc] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFolders] ADD  DEFAULT ((0)) FOR [ParentFolderId]
GO
ALTER TABLE [dbo].[ProjectFolders] ADD  DEFAULT ('True') FOR [isCreateFolder]
GO
ALTER TABLE [dbo].[ProjectFolders] ADD  DEFAULT ('False') FOR [isActive]
GO
ALTER TABLE [dbo].[ProjectFolders] ADD  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[ProjectFolders] ADD  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO
ALTER TABLE [dbo].[ProjectMethods] ADD  DEFAULT ('False') FOR [AllowSummary]
GO
ALTER TABLE [dbo].[ProjectMethods] ADD  DEFAULT ('False') FOR [isActive]
GO
ALTER TABLE [dbo].[ProjectMethods] ADD  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[ProjectMethods] ADD  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO
ALTER TABLE [dbo].[MethodologyStructure]  WITH CHECK ADD FOREIGN KEY([MethodologyID])
REFERENCES [dbo].[Methodology] ([ID])
GO
ALTER TABLE [dbo].[ProjectFiles]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectFolders]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectMethods]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD FOREIGN KEY([SolutionID])
REFERENCES [dbo].[Solutions] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SolutionFolders]  WITH CHECK ADD FOREIGN KEY([SolutionID])
REFERENCES [dbo].[Solutions] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SolutionFolders_Tables]  WITH CHECK ADD FOREIGN KEY([FolderID])
REFERENCES [dbo].[SolutionFolders] ([ID])
GO
ALTER TABLE [dbo].[SolutionFolders_Tables]  WITH CHECK ADD FOREIGN KEY([TableID])
REFERENCES [dbo].[SolutionsDBTables] ([ID])
GO
ALTER TABLE [dbo].[SolutionsDB]  WITH CHECK ADD FOREIGN KEY([SolutionID])
REFERENCES [dbo].[Solutions] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SolutionsDBQuery]  WITH CHECK ADD FOREIGN KEY([SolutionsDBID])
REFERENCES [dbo].[SolutionsDB] ([ID])
GO
ALTER TABLE [dbo].[SolutionsDBQueryColumns]  WITH CHECK ADD FOREIGN KEY([SolutionsDBID])
REFERENCES [dbo].[SolutionsDB] ([ID])
GO
ALTER TABLE [dbo].[SolutionsDBTableColumns]  WITH CHECK ADD FOREIGN KEY([SolutionsDBID])
REFERENCES [dbo].[SolutionsDB] ([ID])
GO
ALTER TABLE [dbo].[SolutionsDBTables]  WITH CHECK ADD FOREIGN KEY([SolutionsDBID])
REFERENCES [dbo].[SolutionsDB] ([ID])
GO
