UPDATE orders
SET
    table_number    = @TableNumber,
    total_price     = @TotalPrice,
    status          = @Status,
    created_time    = @CreatedTime
WHERE id = @Id