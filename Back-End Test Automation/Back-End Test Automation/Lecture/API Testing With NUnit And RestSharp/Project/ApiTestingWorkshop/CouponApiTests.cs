using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingWorkshop
{
    [TestFixture]
    public class CouponApiTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(GlobalConstants.baseUrl);
            token = GlobalConstants.GetAuthenticationToken("admin@gmail.com", "admin@gmail.com");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token is null or empty");
        }

        public void Dispose()
        {
            client.Dispose();
        }

        [Test, Order(1)]
        public void Test_GetAllCoupons()
        {
            // Arrange
            var request = new RestRequest("/coupon", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");

            // Act
            var response = client.Execute(request);
            var coupons = JArray.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(coupons.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");
                Assert.That(coupons.Count, Is.GreaterThan(0), "Array contains no elements");

                var specificCoupons = new string[]
                {
                    "SUMMER21",
                    "WINTER21",
                    "BLACKFRIDAY"
                };

                foreach (var specificCoupon in specificCoupons)
                {
                    Assert.That(coupons.ToString(), Does.Contain(specificCoupon), "Response content does not contain the expected value");
                }

                foreach (var coupon in coupons)
                {
                    Assert.That(coupon["_id"]?.ToString(), Is.Not.Null.Or.Empty, "Coupon ID is null or empty");
                    Assert.That(coupon["name"]?.ToString(), Is.Not.Null.Or.Empty, "Coupon name is null or empty");
                    Assert.That(coupon["expiry"]?.ToString(), Is.Not.Null.Or.Empty, "Coupon expiry is null or empty");
                    Assert.That(coupon["discount"]?.Value<int>(), Is.GreaterThan(0), "Coupon discount is zero or less than zero");
                    Assert.That(DateTime.TryParse(coupon["expiry"]?.ToString(), out var expiryDate), Is.True, "Coupon expiry type is not datetime");
                    Assert.That(expiryDate, Is.GreaterThan(DateTime.Now), "Coupon expiry value is not greater than current date");
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddCoupon()
        {
            // Arrange
            var request = new RestRequest("/coupon", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                name = "Test Coupon",
                discount = 30,
                expiry = "2025-03-03"
            });

            // Act
            var response = client.Execute(request);
            var coupon = JObject.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(coupon["_id"]?.ToString(), Is.Not.Null.Or.Empty, "Coupon ID is null or empty");
                Assert.That(coupon["name"]?.ToString(), Is.EqualTo("TEST COUPON"), "Coupon name does not match the expected value");
                Assert.That(coupon["discount"]?.Value<int>(), Is.EqualTo(30), "Coupon discount does not match the expected value");
                Assert.That(coupon["expiry"]?.ToString(), Is.EqualTo("3.3.2025 г. 0:00:00"), "Coupon expiry does not match the expected value");
                Assert.That(DateTime.TryParse(coupon["expiry"]?.ToString(), out var expiryDate), Is.True, "Coupon expiry type is not datetime");
                Assert.That(expiryDate, Is.GreaterThan(DateTime.Now), "Coupon expiry value is not greater than current date");
            });
        }

        [Test, Order(3)]
        public void Test_UpdateCoupon()
        {
            // Arrange
            var getAllCouponsRequest = new RestRequest("/coupon", Method.Get);
            getAllCouponsRequest.AddHeader("Authorization", $"Bearer {token}");

            // Act
            var getAllCouponsResponse = client.Execute(getAllCouponsRequest);
            var coupons = JArray.Parse(getAllCouponsResponse.Content);
            var coupon = coupons.FirstOrDefault(c => c["name"]?.ToString() == "TEST COUPON");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllCouponsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllCouponsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var updateRequest = new RestRequest("/coupon/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", coupon["_id"]?.ToString());
            updateRequest.AddJsonBody(new
            {
                name = "Demo Coupon",
                discount = 50,
                expiry = "2025-09-06"
            });

            // Act
            var updateResponse = client.Execute(updateRequest);
            var updatedCoupon = JObject.Parse(updateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedCoupon["_id"]?.ToString(), Is.EqualTo(coupon["_id"]?.ToString()), "Coupon ID does not match the expected value");
                Assert.That(updatedCoupon["name"]?.ToString(), Is.EqualTo("DEMO COUPON"), "Coupon name does not match the expected value");
                Assert.That(updatedCoupon["discount"]?.Value<int>(), Is.EqualTo(50), "Coupon discount does not match the expected value");
                Assert.That(updatedCoupon["expiry"]?.ToString(), Is.EqualTo("6.9.2025 г. 0:00:00"), "Coupon expiry does not match the expected value");
                Assert.That(DateTime.TryParse(updatedCoupon["expiry"]?.ToString(), out var expiryDate), Is.True, "Coupon expiry type is not datetime");
                Assert.That(expiryDate, Is.GreaterThan(DateTime.Now), "Coupon expiry value is not greater than current date");
            });
        }

        [Test, Order(4)]
        public void Test_DeleteCoupon()
        {
            // Arrange
            var getAllCouponsRequest = new RestRequest("/coupon", Method.Get);
            getAllCouponsRequest.AddHeader("Authorization", $"Bearer {token}");

            // Act
            var getAllCouponsResponse = client.Execute(getAllCouponsRequest);
            var coupons = JArray.Parse(getAllCouponsResponse.Content);
            var coupon = coupons.FirstOrDefault(c => c["name"]?.ToString() == "DEMO COUPON");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllCouponsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllCouponsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var deleteRequest = new RestRequest("/coupon/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", coupon["_id"]?.ToString());

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/coupon/{id}", Method.Get);
            verifyAfterDeleteRequest.AddHeader("Authorization", $"Bearer {token}");
            verifyAfterDeleteRequest.AddUrlSegment("id", coupon["_id"]?.ToString());

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterDeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterDeleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(verifyAfterDeleteResponse.Content.ToString(), Is.EqualTo("null"), "Response content does not match the expected value");
            });
        }
    }
}
