using Avalonia.Controls;
using Avalonia.Interactivity;

namespace InventorySystemNew;

public partial class MainWindow : Window
{
    /// this is bulk item sold by liter
    private readonly Item HydraulicPumpOil = new BulkItem
    {
        Name = "hydraulic pump oil",
        PricePerUnit = 59m,
        MeasurementUnit = "L"
    };

    /// this is unit item sold in units
    private readonly Item PlcModule = new UnitItem
    {
        Name = "PLC module",
        PricePerUnit = 1250m,
        Weight = 1m
    };

    /// another item sold in units
    private readonly Item ServoMotor = new UnitItem
    {
        Name = "servo motor",
        PricePerUnit = 2100m,
        Weight = 2m
    };

    public MainWindow()
    {
        InitializeComponent(); /// starts the window
        DataContext = this;    /// connects this file with the XAML so data can be shown

        /// creates a customer named Sara and makes an order for her
        var sara = new Customer("Sara");
        var o1 = new Order();
        o1.OrderLines.Add(new OrderLine(ServoMotor, 1)); /// 1 servo motor
        o1.OrderLines.Add(new OrderLine(PlcModule, 2));  /// 2 PLC modules
        sara.CreateOrder(OrderBook, o1);                 /// adds her order to the orderbook

        /// creates a customer named Carl and makes an order for him
        var carl = new Customer("Carl");
        var o2 = new Order();
        o2.OrderLines.Add(new OrderLine(HydraulicPumpOil, 15)); /// 15 liters of oil
        carl.CreateOrder(OrderBook, o2);                        /// adds his order to the orderbook
    }

    /// orderbook keeps track of queued and processed orders
    public OrderBook OrderBook { get; } = new();

    /// runs when the button is clicked
    public void ProcessNextOrder_OnClick(object? sender, RoutedEventArgs e)
    {
        ProcessNextOrder();
    }

    /// takes the first order in queue, moves it to processed list,
    /// and updates the total revenue
    public void ProcessNextOrder()
    {
        OrderBook.ProcessNextOrder();
    }
}
