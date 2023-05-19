using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(
            ILogger<PointsOfInterestController> logger,
            IMailService mailService,
            ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            this._cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            this._logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            this._mailService = mailService ??
                throw new ArgumentNullException(nameof(mailService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(
            int cityId)
        {
          if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                _logger.LogInformation(
                    $"City with id {cityId} wasn't found when accessing points of interest ");
                return NotFound();
            }

          var pointsOfInterestForCity = await _cityInfoRepository
                .GetPointsOfInterestForCityAsync(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));
        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(
            int cityId, int pointOfInterestId)
        {
            if(!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository.
                GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            int cityId,
            PointOfInterestForCreationDto pointOfInterest)
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId) )
            {
                return NotFound();
            }

            var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);

            await _cityInfoRepository.AddPointOfInterestForCityAsync(
                cityId,  finalPointOfInterest);

            await _cityInfoRepository.SaveChangesAsync();

            var createdPointOfInterestToReturn =
                _mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = finalPointOfInterest.Id
                },
                createdPointOfInterestToReturn);
        }
        [HttpPut("{pointofinterestid}")]
        public async Task<ActionResult> UpdatePointOfInterest(
            int cityId,
            int pointOfInterestId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            if(!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntities = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
            if (pointOfInterestEntities == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, pointOfInterestEntities);

            await _cityInfoRepository .SaveChangesAsync();

            return NoContent();

        }

        // [HttpPatch("{pointofinterestid}")]
        // public ActionResult<PointOfInterestDto> PartiallyUpdatePointOfInterest(
        //   int cityId,
        //   int pointOfInterestId,
        //   JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        // {
        //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
        //     if (city == null)
        //     {
        //         return NotFound();
        //     }

        //     var pointOfInterestFromStore = city.PointsOfInterest
        //         .FirstOrDefault(c => c.Id == pointOfInterestId);
        //     if (pointOfInterestFromStore == null)
        //     {
        //         return NotFound();
        //     }

        //     var pointOfInterestToPatch =
        //         new PointOfInterestForUpdateDto()
        //         {
        //             Name = pointOfInterestFromStore.Name,
        //             Description = pointOfInterestFromStore.Description
        //         };

        //     patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if(!TryValidateModel(pointOfInterestToPatch))
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        //     pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

        //     return NoContent();
        // }

        // [HttpDelete("{pointofinterestid}")]
        // public ActionResult DeletePointOfInterest(int cItyId,
        //     int pointOfInterestId)
        // {
        //     var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cItyId);
        //     if (city == null)
        //     {
        //         return NotFound();
        //     }
        //     var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
        //     if (pointOfInterestFromStore == null)
        //     {
        //         return NotFound();
        //     }

        //     city.PointsOfInterest.Remove(pointOfInterestFromStore);
        //     _mailService.Send(
        //         "Point of interest deleted.",
        //         $"The Point of interest called {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted.");

        //     return NoContent();
        // }

    }
}
