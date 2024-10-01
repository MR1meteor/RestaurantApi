UPDATE order_items
SET
    order_id    = @OrderId,
    dish_id     = @DishId,
    status      = @Status,
    price       = @Price
WHERE id = @Id