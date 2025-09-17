SELECT * FROM ProductPromotions

select * from Promotions

SELECT * FROM StockProducts

select * from Orders

select * 
from OrderItems o (nolock)
inner join Products p (nolock) on p.Id = o.ProductId
left join ProductPromotions pp (nolock) on p.Id = pp.ProductId
left join Promotions po (nolock) on po.Id = pp.PromotionId
where OrderId = 6

select * from Clients
