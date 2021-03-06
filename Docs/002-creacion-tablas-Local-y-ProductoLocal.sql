USE [PracticaEF]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 6/3/2020 8:35:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[IdLocal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Direccion] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[IdLocal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductosLocal]    Script Date: 6/3/2020 8:35:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductosLocal](
	[IdLocal] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
 CONSTRAINT [PK_ProductosLocal] PRIMARY KEY CLUSTERED 
(
	[IdLocal] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProductosLocal]  WITH CHECK ADD  CONSTRAINT [FK_ProductosLocal_Local] FOREIGN KEY([IdLocal])
REFERENCES [dbo].[Local] ([IdLocal])
GO
ALTER TABLE [dbo].[ProductosLocal] CHECK CONSTRAINT [FK_ProductosLocal_Local]
GO
ALTER TABLE [dbo].[ProductosLocal]  WITH CHECK ADD  CONSTRAINT [FK_ProductosLocal_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[ProductosLocal] CHECK CONSTRAINT [FK_ProductosLocal_Producto]
GO
