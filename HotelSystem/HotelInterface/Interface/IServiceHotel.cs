using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelInterface.DTOs;
using HotelSystem.DTOs;
using HotelSystem.Exception;
using HotelSystem.Model;

namespace HotelInterface.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceHotel
    {

/// <summary>
/// 
/// </summary>
/// <param name="passPortNUmber"></param>
/// <returns>Returns all the bookings associated with the passportnummber</returns>

        [OperationContract]

        List<BookingDetails> FindBookings(int passPortNUmber);

        /// <summary>
        /// Cancels the booking via bookingidentifier and if something goes wrong it will throw an exception 
        /// if the booking is not found or if a cancellation has been made  
        /// </summary>
        /// <param name="bookingIdentifier"></param>
        [OperationContract]
        [FaultContract(typeof(BookingNotFoundException))]
        [FaultContract(typeof(BookingCancelledAllreadyException))]
        void CancelBooking(BookingIdentifier bookingIdentifier);


        /// <summary>
        /// Finds a booking by id and if not it throws an exception 
        /// </summary>
        /// <param name="bookingIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(BookingNotFoundException))]
        BookingDetails FindBookingByid(BookingIdentifier bookingIdentifier);

      

     
        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hotel"></param>
        /// <param name="roomType"></param>
        /// <returns> List of rooms based on given parameters </returns>
        [OperationContract]
        List<RoomDetails> FindRooms( DateTime date, HotelIdentifier hotel, string roomType);

        /// <summary>
        /// Addes a new Hotel based on given parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="adress"></param>
        /// <param name="hotelChainIdentifier"></param>
        [OperationContract]
        void AddNewHotel(string name, string city, string adress ,HotelChainIdentifier hotelChainIdentifier);


        /// <summary>
        /// Creates a booking via the parameters if any of the rooms not available it will throw an exception
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="numberGuest"></param>
        /// <param name="listOfRooms"></param>
        /// <param name="passportNumber"></param>
        /// <param name="guestNumber"></param>
        /// <returns></returns>
        [OperationContract]
    
        [FaultContract(typeof(RoomNotAvailableException))]
        bool CreateBooking(DateTime startDate, DateTime endDate,  int numberGuest, List<RoomIdentifier> listOfRooms,
            int passportNumber, string guestNumber);

    }
}
