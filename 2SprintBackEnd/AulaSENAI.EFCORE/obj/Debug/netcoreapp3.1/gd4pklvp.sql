ALTER TABLE [PedidoItem] ADD [Quantidade] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200910013357_AlterTablePedidosItens', N'3.1.8');

GO

