use OrderManagement


INSERT INTO Clients (Name, Email) VALUES ('Ana Souza', 'ana.souza@email.com');
INSERT INTO Clients (Name, Email) VALUES ('Carlos Lima', 'carlos.lima@email.com');
INSERT INTO Clients (Name, Email) VALUES ('Fernanda Oliveira', 'fernanda.oliveira@email.com');
INSERT INTO Clients (Name, Email) VALUES ('João Mendes', 'joao.mendes@email.com');
INSERT INTO Clients (Name, Email) VALUES ('Mariana Costa', 'mariana.costa@email.com');
INSERT INTO Clients (Name, Email) VALUES ('Luciana Ribeiro', 'luciana.ribeiro@email.com');
INSERT INTO Clients (Name, Email) VALUES ('Beatriz Rocha', 'beatriz.rocha@email.com');
INSERT INTO Clients (Name, Email) VALUES ('Tiago Silva', 'tiago.silva@email.com');


INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU001', 'Camisa Polo Masculina', 89.90, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU002', 'Calça Jeans Feminina', 129.99, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU003', 'Tênis Esportivo', 199.50, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU004', 'Jaqueta Corta-Vento', 249.00, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU005', 'Mochila Escolar', 79.90, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU006', 'Relógio Digital', 149.99, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU007', 'Óculos de Sol', 89.00, 0);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU008', 'Boné Estampado', 39.90, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU009', 'Meia Esportiva (Kit c/ 3)', 29.99, 1);
INSERT INTO Products (Sku, Name, Price, IsActive) VALUES ('SKU010', 'Camisa Social Feminina', 99.90, 1);

INSERT INTO Promotions (Name, PromotionType, [Percent], IsActive)
VALUES ('Desconto de 10% em toda a loja', 1, 10.00, 1);
INSERT INTO Promotions (Name, PromotionType, FixedAmount, IsActive)
VALUES ('R$20 de desconto em compras acima de R$100', 2, 20.00, 1);
INSERT INTO Promotions (Name, PromotionType, BuyX, PayY, IsActive)
VALUES ('Leve 3, Pague 2 em camisetas', 3, 3, 2, 1);
INSERT INTO Promotions (Name, PromotionType, [Percent], IsActive)
VALUES ('Desconto sazonal de 15%', 1, 15.00, 0);
INSERT INTO Promotions (Name, PromotionType, FixedAmount, IsActive)
VALUES ('R$50 off em tênis esportivos', 2, 50.00, 1);
INSERT INTO Promotions (Name, PromotionType, BuyX, PayY, IsActive)
VALUES ('Leve 2, Pague 1 em acessórios', 3, 2, 1, 1);
INSERT INTO Promotions (Name, PromotionType, [Percent], IsActive)
VALUES ('15% para primeira compra', 1, 15.00, 1);


INSERT INTO Stocks (Name, Localization) VALUES ('Estoque Central', 'São Paulo - SP');
INSERT INTO Stocks (Name, Localization) VALUES ('Depósito Zona Norte', 'São Paulo - SP');
INSERT INTO Stocks (Name, Localization) VALUES ('Centro de Distribuição RJ', 'Rio de Janeiro - RJ');
INSERT INTO Stocks (Name, Localization) VALUES ('Armazém Sul', 'Porto Alegre - RS');
INSERT INTO Stocks (Name, Localization) VALUES ('Estoque Nordeste', 'Recife - PE');
INSERT INTO Stocks (Name, Localization) VALUES ('Depósito Campinas', 'Campinas - SP');
INSERT INTO Stocks (Name, Localization) VALUES ('CD Belo Horizonte', 'Belo Horizonte - MG');
INSERT INTO Stocks (Name, Localization) VALUES ('Estoque Temporário', NULL);
INSERT INTO Stocks (Name, Localization) VALUES ('Depósito de Retorno', 'Curitiba - PR');
INSERT INTO Stocks (Name, Localization) VALUES ('Armazém de Exportação', 'Santos - SP');

INSERT INTO ProductPromotions (ProductId, PromotionId) VALUES (5, 6);
INSERT INTO ProductPromotions (ProductId, PromotionId) VALUES (6, 7);
INSERT INTO ProductPromotions (ProductId, PromotionId) VALUES (7, 1);
INSERT INTO ProductPromotions (ProductId, PromotionId) VALUES (8, 2);
INSERT INTO ProductPromotions (ProductId, PromotionId) VALUES (9, 6);
INSERT INTO ProductPromotions (ProductId, PromotionId) VALUES (10, 7);

INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (1, 1, 100);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (2, 2, 80);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (3, 3, 120);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (4, 4, 60);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (5, 5, 150);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (6, 6, 90);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (7, 7, 70);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (8, 8, 50);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (9, 9, 200);
INSERT INTO StockProducts (StockId, ProductId, Qty) VALUES (10, 10, 110);


