USE [PracticaEF]
GO
/****** Object:  Table [dbo].[DetalleProducto]    Script Date: 6/3/2020 10:10:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleProducto](
	[IdProducto] [int] NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Medidas] [nvarchar](200) NULL,
	[Peso] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetalleProducto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[DetalleProducto]  WITH CHECK ADD  CONSTRAINT [FK_DetalleProducto_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleProducto] CHECK CONSTRAINT [FK_DetalleProducto_Producto]
GO
