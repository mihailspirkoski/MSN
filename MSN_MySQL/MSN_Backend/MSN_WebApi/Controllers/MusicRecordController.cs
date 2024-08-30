using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSN_Application.Services.Interface;
using MSN_Domain.Entities;
using MSN_WebApi.ViewModels_DTO;
using System.Security.Claims;

namespace MSN_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordController : ControllerBase
    {

        private readonly IMusicRecordService _musicRecordService;
        private readonly IUserService _userService;
        private readonly UserManager<MSNUser> _userManager;

        public MusicRecordController(IMusicRecordService musicRecordService, IUserService userService, UserManager<MSNUser> userManager)
        {
            _musicRecordService = musicRecordService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet("get-all-records")]
        public async Task<IActionResult> GetAllMusicRecords()
        {
            List<MusicRecord> musicRecords = _musicRecordService.GetAllRecords();
            return Ok(musicRecords);
        }

        [HttpGet("get-single-record/{recordId}")]
        public async Task<IActionResult> GetASingleRecord([FromRoute(Name="recordId")] string id)
        {
           int recordId = Int32.Parse(id);
           MusicRecord musicRecord = _musicRecordService.GetRecord(recordId);
            return Ok(musicRecord);
        }

        [HttpPost("create-record")]
        public async Task<IActionResult> CreateNewMusicRecord(MusicRecordDTO record)
        {
            if(record == null)
            {
                return BadRequest("");
            }

            MusicRecord recordToAdd = new MusicRecord();
            recordToAdd.title = record.title;
            recordToAdd.artist = record.artist;
            recordToAdd.genre = record.genre;
            recordToAdd.type = record.type;
            recordToAdd.rating = record.rating;
            recordToAdd.imageUrl = record.imageUrl;
            recordToAdd.url = record.url;

            _musicRecordService.CreateNewRecord(recordToAdd);
            return Ok("Record greated");
        }

        [HttpPost("edit-record")]
        public async Task<IActionResult> EditMusicRecord(MusicRecord recordToEdit)
        {
            if (recordToEdit == null || recordToEdit.Id == 0)
            {
                return BadRequest("");
            }
            _musicRecordService.UpdateRecord(recordToEdit);
            return Ok();
        }

        [HttpPost("delete-record")]
        public async Task<IActionResult> DeleteMusicRecord(MusicRecord recordToDelete)
        {
            if (recordToDelete == null || recordToDelete.Id == 0)
            {
                return BadRequest("");
            }
            _musicRecordService.DeleteRecord(recordToDelete);
            return Ok();
        }


        [HttpGet("get-rock-records")]
        public async Task<IActionResult> GetAllRockRecords()
        {
            List<MusicRecord> musicRecords = _musicRecordService.GetAllRecords();
            List<MusicRecord> rockRecords = new List<MusicRecord>();
            foreach (var musicRecord in musicRecords)
            {
                if (musicRecord.genre == "Rock")
                {
                    rockRecords.Add(musicRecord);
                }
            }
            return Ok(rockRecords);
        }

        [HttpGet("get-pop-records")]
        public async Task<IActionResult> GetAllPopRecords()
        {
            List<MusicRecord> musicRecords = _musicRecordService.GetAllRecords();
            List<MusicRecord> popRecords = new List<MusicRecord>();
            foreach(var musicRecord in musicRecords)
            {
                if(musicRecord.genre == "Pop")
                {
                    popRecords.Add(musicRecord);
                }
            }
            return Ok(popRecords);
        }
        [HttpGet("get-hiphop-records")]
        public async Task<IActionResult> GetAllHipHopRecords()
        {
            List<MusicRecord> musicRecords = _musicRecordService.GetAllRecords();
            List<MusicRecord> hiphopRecords = new List<MusicRecord>();
            foreach (var musicRecord in musicRecords)
            {
                if (musicRecord.genre == "HipHop")
                {
                    hiphopRecords.Add(musicRecord);
                }
            }
            return Ok(hiphopRecords);
        }
        [HttpGet("get-metal-records")]
        public async Task<IActionResult> GetAllMetalRecords()
        {
            List<MusicRecord> musicRecords = _musicRecordService.GetAllRecords();
            List<MusicRecord> metalRecords = new List<MusicRecord>();
            foreach (var musicRecord in musicRecords)
            {
                if (musicRecord.genre == "Metal")
                {
                    metalRecords.Add(musicRecord);
                }
            }
            return Ok(metalRecords);
        }
        [HttpGet("get-classical-records")]
        public async Task<IActionResult> GetAllClassicalRecords()
        {
            List<MusicRecord> musicRecords = _musicRecordService.GetAllRecords();
            List<MusicRecord> classicalRecords = new List<MusicRecord>();
            foreach (var musicRecord in musicRecords)
            {
                if (musicRecord.genre == "Classical")
                {
                    classicalRecords.Add(musicRecord);
                }
            }
            return Ok(classicalRecords);
        }
        [HttpGet("get-electronic-records")]
        public async Task<IActionResult> GetAllElectronicRecords()
        {
            List<MusicRecord> musicRecords = _musicRecordService.GetAllRecords();
            List<MusicRecord> electronicRecords = new List<MusicRecord>();
            foreach (var musicRecord in musicRecords)
            {
                if (musicRecord.genre == "Electronic")
                {
                    electronicRecords.Add(musicRecord);
                }
            }
            return Ok(electronicRecords);
        }


    }
}
