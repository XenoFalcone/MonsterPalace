using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvailableRoomsPanelUI : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _availableRoomsPanel;

    [Header("Data")]
    [SerializeField] private SO_Hotel _hotel;

    [Space(10)]
    [Header("Prefabs")]
    [SerializeField] private GameObject _NoRoomBuildPrefab;
    [SerializeField] private GameObject _NoRoomAvailbalePrefab;
    [SerializeField] private GameObject _roomPrefab;

    [Space(10)]
    [Header("References")]
    [SerializeField] private PlacementSystem _placementSystem;
    [SerializeField] private MonsterPanelUI _monsterPanelUI;
    
    public string monsterID;

    private void Start()
    {
        _placementSystem.OnRoomPlaced += UpdateRoomsList;
        _monsterPanelUI.OnOpen += UpdateRoomsList;
    }

    public bool HasBuildedRoomsInHotel()
    {
        List<Room> bedrooms = _hotel.rooms.FindAll(room => room.roomType.roomType == RoomType.BEDROOM);
        
        return bedrooms.Count > 0;
    }

    public List<Room> GetAvailableRoomsInHotel()
    {
        List<Room> availableRooms = _hotel.rooms.FindAll(room => room.roomType.roomType == RoomType.BEDROOM && room.monsterID == null);

        return availableRooms;
    }

    public void InstantiateRooms()
    {
        List<Room> availableRooms = GetAvailableRoomsInHotel();

        if ( availableRooms.Count == 0 )
        {
            Instantiate( _NoRoomAvailbalePrefab, _availableRoomsPanel.transform );
            return;
        }

        foreach (Room room in availableRooms)
        {
            var button = Instantiate( _roomPrefab, _availableRoomsPanel.transform ); 
            // ajouter un listener pour le bouton
            button.GetComponentInChildren<Button>().onClick.AddListener(() => SelectRoom(room));
        }
    }

    public void UpdateRoomsList()
    {
        foreach ( Transform child in _availableRoomsPanel.transform )
        {
            Destroy(child.gameObject);
        }

        if ( HasBuildedRoomsInHotel() )
        {
            InstantiateRooms();
        }
        else
        {
            Instantiate( _NoRoomBuildPrefab, _availableRoomsPanel.transform);
        }
    }

    public void SelectRoom(Room room)
    {
        _monsterPanelUI.AddMonsterToRoom(room);
    }
}