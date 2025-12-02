# TrainBookingApp

A complete train ticket booking application built with **Blazor Server** and **.NET 8.0**. This application provides a user-friendly interface for searching trains, selecting seats, and booking tickets.

## Features

### 🔍 Train Search
- Search trains between origin and destination stations
- Select travel date and number of passengers
- Validation to ensure origin ≠ destination
- Display available trains with schedules and pricing

### 🚆 Train Listing
- View available trains based on search criteria
- Display train details:
  - Train name and number
  - Departure and arrival times
  - Journey duration
  - Available seat classes (Sleeper, AC, First Class, etc.)
  - Prices per class
  - Available seats count

### 💺 Seat Selection
- Interactive seat map component
- Visual indication of seat availability:
  - Available seats (green)
  - Selected seats (blue)
  - Booked seats (gray)
- Real-time seat selection updates

### 👤 Passenger Details
- Form for each passenger with:
  - Full name, age, and gender
  - ID proof type and number
  - Contact details for primary passenger
- Comprehensive form validation

### 💳 Booking Summary
- Complete booking details review:
  - Train and journey information
  - Selected seats
  - Passenger details
  - Price breakdown
  - Total amount

### 🎫 Booking Confirmation
- Success page with:
  - Booking reference number (PNR)
  - QR code representation
  - Journey summary
  - Print ticket option
  - Option to view all bookings

### 🔐 User Authentication
- User registration with validation
- Secure login/logout
- Password requirements enforcement
- User profile display

### 📋 My Bookings
- View all user bookings
- Filter by status (Confirmed, Cancelled, Completed)
- View detailed booking information
- Cancel upcoming bookings

### 📱 Responsive Design
- Mobile-friendly layout
- Works seamlessly on desktop, tablet, and mobile devices
- Bootstrap 5 for responsive UI

## Technology Stack

- **Framework**: ASP.NET Core 8.0 with Blazor Server
- **Database**: Entity Framework Core with SQLite
- **Authentication**: ASP.NET Core Identity
- **UI Framework**: Bootstrap 5
- **Icons**: Bootstrap Icons
- **Runtime**: .NET 8.0

## Project Structure

```
TrainBookingApp/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor          # Main layout component
│   │   └── NavMenu.razor             # Navigation menu
│   ├── Pages/
│   │   ├── Home.razor                # Landing page
│   │   ├── SearchTrains.razor        # Train search page
│   │   ├── SeatSelection.razor       # Seat selection page
│   │   ├── PassengerDetails.razor    # Passenger information form
│   │   ├── BookingSummary.razor      # Booking review page
│   │   ├── BookingConfirmation.razor # Confirmation page
│   │   ├── MyBookings.razor          # User bookings list
│   │   ├── Login.razor               # Login page
│   │   ├── Register.razor            # Registration page
│   │   └── Logout.razor              # Logout handler
│   ├── Shared/
│   │   ├── SeatMap.razor             # Interactive seat map
│   │   ├── TrainCard.razor           # Train display card
│   │   └── BookingCard.razor         # Booking display card
│   ├── _Imports.razor                # Global using directives
│   ├── App.razor                     # App root component
│   └── Routes.razor                  # Routing configuration
├── Data/
│   ├── ApplicationDbContext.cs       # EF Core database context
│   └── SeedData.cs                   # Database seeding
├── Models/
│   ├── ApplicationUser.cs            # User model
│   ├── Station.cs                    # Station model
│   ├── Train.cs                      # Train model
│   ├── Schedule.cs                   # Train schedule model
│   ├── Seat.cs                       # Seat model
│   ├── SeatClass.cs                  # Seat class enumeration
│   ├── Booking.cs                    # Booking model
│   ├── BookingStatus.cs              # Booking status enum
│   └── Passenger.cs                  # Passenger model
├── Services/
│   ├── IStationService.cs            # Station service interface
│   ├── StationService.cs             # Station service implementation
│   ├── ITrainService.cs              # Train service interface
│   ├── TrainService.cs               # Train service implementation
│   ├── IBookingService.cs            # Booking service interface
│   └── BookingService.cs             # Booking service implementation
├── wwwroot/
│   ├── css/
│   │   └── app.css                   # Custom styles
│   └── bootstrap/                    # Bootstrap files
├── Program.cs                        # Application entry point
├── appsettings.json                  # Configuration
├── TrainBookingApp.csproj            # Project file
└── README.md                         # This file
```

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- A code editor (Visual Studio 2022, VS Code, or Rider)
- Web browser (Chrome, Firefox, Edge, or Safari)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/NAGRAJMOGER/TrainBookingApp.git
cd TrainBookingApp
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Build the Application

```bash
dotnet build
```

### 4. Run the Application

```bash
dotnet run
```

The application will start and be available at:
- HTTP: `http://localhost:5179`
- HTTPS: `https://localhost:7179`

### 5. Access the Application

Open your web browser and navigate to the local URL displayed in the console.

## Sample Data

The application is pre-seeded with:

### Stations
- Mumbai Central (MMCT)
- New Delhi (NDLS)
- Bangalore City (BNC)
- Chennai Central (MAS)
- Howrah Junction (HWH)
- Pune Junction (PUNE)
- Hyderabad Deccan (HYB)
- Ahmedabad Junction (ADI)
- Jaipur Junction (JP)
- Lucknow (LKO)
- Chandigarh (CDG)
- Bhopal Junction (BPL)

### Trains
- 8 sample trains with multiple schedules
- Different seat classes (Sleeper, AC 3-Tier, AC 2-Tier, AC 1-Tier, First Class, Chair Car, Second Sitting)
- Realistic pricing and seat availability

## Usage Guide

### For New Users

1. **Register**: Click "Register" in the navigation menu
   - Provide your full name, email, phone number, and password
   - Password must be at least 6 characters with uppercase, lowercase, and digit

2. **Login**: Use your registered credentials to log in

3. **Search Trains**: 
   - Select origin and destination stations
   - Choose travel date and number of passengers
   - Click "Search Trains"

4. **Book Ticket**:
   - Select a train from the search results
   - Choose seats from the interactive seat map
   - Fill in passenger details
   - Review booking summary
   - Confirm booking

5. **View Bookings**:
   - Navigate to "My Bookings"
   - View all your bookings
   - Filter by status
   - Cancel upcoming bookings if needed

### For Development

#### Database

The application uses SQLite database (`trainbooking.db`) which is created automatically on first run. The database is seeded with sample data.

To reset the database:
```bash
rm trainbooking.db*
dotnet run
```

#### Configuration

Update `appsettings.json` to configure:
- Connection strings
- Logging levels
- Other application settings

## Key Components

### Authentication & Authorization
- Built-in ASP.NET Core Identity for user management
- Secure password hashing
- Session-based authentication
- Role-based authorization for protected routes

### Services (Dependency Injection)
- **StationService**: Manages station data
- **TrainService**: Handles train searches and schedule queries
- **BookingService**: Manages bookings and PNR generation

### Responsive Design
- Bootstrap 5 for responsive layout
- Mobile-first approach
- Touch-friendly controls for mobile devices
- Print-friendly ticket design

## API Endpoints

The application is a server-side Blazor app with the following page routes:

- `/` - Home page
- `/search` - Train search
- `/seat-selection` - Seat selection (with query parameters)
- `/passenger-details` - Passenger information form
- `/booking-summary` - Booking review
- `/booking-confirmation` - Confirmation page
- `/my-bookings` - User bookings list (requires authentication)
- `/login` - Login page
- `/register` - Registration page
- `/logout` - Logout handler

## Future Enhancements

- Payment gateway integration
- Email notifications
- PDF ticket generation
- Train tracking
- Refund management
- Admin dashboard
- Multi-language support
- Social media login
- Waiting list management

## Troubleshooting

### Application won't start
- Ensure .NET 8.0 SDK is installed: `dotnet --version`
- Check if port 5179 is available
- Review error messages in the console

### Database errors
- Delete the database file and restart: `rm trainbooking.db*`
- Check file permissions in the application directory

### Authentication issues
- Clear browser cookies and cache
- Ensure Identity tables are created in the database

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available for educational purposes.

## Author

NAGRAJMOGER

## Acknowledgments

- Built with ASP.NET Core and Blazor
- UI powered by Bootstrap 5
- Icons from Bootstrap Icons