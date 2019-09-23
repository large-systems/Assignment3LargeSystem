using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HotelSystem.Model;

namespace HotelSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceHotel
    {

        // TODO: Add your service operations here

        /// <summary>
        /// Logs on to the system
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        [OperationContract]
        void LogOn(int id , string password);

        /// <summary>
        /// Shows a list of bookings
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Booking> SelectBooking();

        /// <summary>
        /// Finds a booking  
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="roomType"></param>
        /// <param name="passportNummber"></param>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [OperationContract]
        void FindBooking (DateTime startDate, DateTime endDate, string roomType, int passportNummber, Hotel hotel);

        /// <summary>
        /// calls upon to show a specific booking
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [OperationContract]
        Booking SelectSpecificBooking(DateTime date);

        /// <summary>
        ///  fuction that finds a booking
        /// </summary>
        /// <param name="date"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [OperationContract]
        List<Hotel> FindHotelRoom(DateTime date , string city);

        /// <summary>
        /// method that shows a list of rooms
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hotel"></param>
        /// <param name="roomType"></param>
        /// <returns></returns>
        [OperationContract]
        List<Room> FindRooms( DateTime date, Hotel hotel, string roomType);

        /// <summary>
        /// selects a room
        /// </summary>
        [OperationContract]
        void SelectRoom();

    }
}
