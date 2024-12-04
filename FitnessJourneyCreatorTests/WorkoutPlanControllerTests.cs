using FitnessJourneyCreator.Controllers;
using FitnessJourneyCreator.Data;
using FitnessJourneyCreator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessJourneyCreatorTests
{
    [TestClass]
    public class WorkoutPlanControllerTests
    {
        // Shared objects to be used in tests
        private ApplicationDbContext _context;
        WorkoutPlansController controller;

        // startup method that creates db automatically before each test runs
        [TestInitialize]
        public void TestInitialize()
        {
            // create new in memory database to pass as dependency to the controller
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // Add data to the mock database
            _context.WorkoutPlans.Add(new WorkoutPlan
            {
                PlanName = "Beginner Strength Training",
                PlanDescription = "A 4-week plan focused on building strength for beginners.",
                CreatedAt = DateTime.Now.AddDays(-30), // Plan created 30 days ago
            });

            _context.WorkoutPlans.Add(new WorkoutPlan
            {
                PlanName = "Intermediate Fat Loss",
                PlanDescription = "A 6-week intermediate-level plan designed to burn fat.",
                CreatedAt = DateTime.Now.AddDays(-60), // Plan created 60 days ago
            });

            _context.WorkoutPlans.Add(new WorkoutPlan
            {
                PlanName = "Advanced Powerlifting",
                PlanDescription = "An 8-week plan for advanced lifters to prepare for a meet.",
                CreatedAt = DateTime.Now.AddDays(-90), // Plan created 90 days ago
            });

            // Save the changes to the mock database
            _context.SaveChanges();

            // instantiate instance of workoutplanscontroller and pass mock db to constructor
            controller = new WorkoutPlansController(_context);
        }



        // A test to confirm that when the create method is called, the correct view is returned
        [TestMethod]
        public void CreateReturnsView()
        {
            // Arrange and act (Create the result variable and set it equal to the result of calling the create method
            var result = (ViewResult)controller.Create();

            Assert.AreEqual("Create", result.ViewName);

        }

        // A test to confirm that valid objects are added to the db
        [TestMethod]
        public void CreateAddsObjectToDB()
        {
            // Arrange (create a workout plan mock object)
            var newPlan = new WorkoutPlan
            {
                PlanName = "Starter",
                PlanDescription = "A beginner workout program",
                CreatedAt = DateTime.Now
            };

            // Act (create a workout plan using the controller)
            var result = controller.Create(newPlan);

            Assert.AreEqual(4, _context.WorkoutPlans.Count());
        }


        // Test for when model.isValid is true, to confirm that there is a redirect to the index
        [TestMethod]
        public void CreateValidObjectRedirectsToIndex()
        {
            // Arrange (create a workout plan mock object)
            var newPlan = new WorkoutPlan
            {
                PlanName = "Starter",
                PlanDescription = "A beginner workout program",
                CreatedAt = DateTime.Now
            };

            var result = (RedirectToActionResult)controller.Create(newPlan).Result;

            Assert.AreEqual("Index", result.ActionName);

        }


        // Test for when ModelState.IsValid is false, to confirm that the object is not added to the db
        [TestMethod]
         public void CreateDoesNotAddInvalidObject()
        {
            var newPlan = new WorkoutPlan
            {
                PlanName = null,
                PlanDescription = "The best program",
                CreatedAt = DateTime.Now
            };

            // Simulate invalid ModelState due to missing PlanName
            controller.ModelState.AddModelError("PlanName", "Plan Name is required.");

            // Act
            var result = controller.Create(newPlan);

            // Assert
            Assert.AreEqual(3, _context.WorkoutPlans.Count());
        }


        [TestMethod]
       public void CreateDoesNotAddInvalidDate()
        {
            var invalidPlan = new WorkoutPlan
            {
                PlanName = "Valid Plan",
                PlanDescription = "Valid Description",
                CreatedAt = DateTime.MinValue // Invalid date
            };

            controller.ModelState.AddModelError("CreatedAt", "Created At is not a valid date.");

            var result = controller.Create(invalidPlan);

            Assert.AreEqual(3, _context.WorkoutPlans.Count());

        }

        [TestMethod]
        public void CreateDoesNotAddInvalidDescription()
        {
            var invalidPlan = new WorkoutPlan
            {
                PlanName = "Valid Plan",
                PlanDescription = null,
                CreatedAt = DateTime.Now
            };

            var result = controller.Create(invalidPlan);


            controller.ModelState.AddModelError("PlanDescription", "Plan description is not valid.");


            Assert.AreEqual(3, _context.WorkoutPlans.Count());

        }


        // Test for when ModelState.IsValid is false, to confirm that the correct view is returned
        [TestMethod]
        public void CreateInvalidInputReturnsView()
        {
            // Create the mock object
            var newPlan = new WorkoutPlan
            {
                PlanName = null,
                PlanDescription = "The best program",
                CreatedAt = DateTime.Now
            };

            controller.ModelState.AddModelError("PlanName", "Plan Name is required.");

            // Act
            var result = (ViewResult)controller.Create(newPlan).Result;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

    }
}