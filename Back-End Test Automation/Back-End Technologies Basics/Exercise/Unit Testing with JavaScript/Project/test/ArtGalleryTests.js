import { expect } from 'chai';
import { artGallery } from '../ArtGallery.js';

describe('ArtGallery Object Tests', function () {

    describe('AddArtwork Function Tests', function () {

        it('Test: Should return error if title parameter passed to addArtwork function is a number', function () {
            // Arrange
            let titleParameter = 5;
            let dimensionsParameter = '30 x 40';
            let artistParameter = 'Picasso';
            let errorMessage = 'Invalid Information!'

            // Act

            // Assert
            expect(() => artGallery.addArtwork(titleParameter, dimensionsParameter, artistParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if artist parameter passed to addArtwork function is a number', function () {
            // Arrange
            let titleParameter = 'Guernica';
            let dimensionsParameter = '30 x 40';
            let artistParameter = 8;
            let errorMessage = 'Invalid Information!'

            // Act

            // Assert
            expect(() => artGallery.addArtwork(titleParameter, dimensionsParameter, artistParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if dimensions parameter passed to addArtwork function is a number', function () {
            // Arrange
            let titleParameter = 'Sunflowers';
            let dimensionsParameter = 4;
            let artistParameter = 'Van Gogh';
            let errorMessage = 'Invalid Dimensions!'

            // Act

            // Assert
            expect(() => artGallery.addArtwork(titleParameter, dimensionsParameter, artistParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if value of artits parameter passed to addArtwork function is different from the given ones', function () {
            // Arrange
            let titleParameter = 'Mona Lisa';
            let dimensionsParameter = '50 x 70';
            let artistParameter = 'Leonardo da Vinci';
            let errorMessage = 'This artist is not allowed in the gallery!'

            // Act

            // Assert
            expect(() => artGallery.addArtwork(titleParameter, dimensionsParameter, artistParameter)).to.throw(errorMessage);
        });

        it('Test: Should return message if all three parameters passed to addArtwork function are valid', function () {
            // Arrange
            let titleParameter = 'Starry Night';
            let dimensionsParameter = '120 x 90';
            let artistParameter = 'Van Gogh';
            let expected = `Artwork added successfully: '${titleParameter}' by ${artistParameter} with dimensions ${dimensionsParameter}.`

            // Act
            let actual = artGallery.addArtwork(titleParameter, dimensionsParameter, artistParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

    });

    describe('CalculateCosts Function Tests', function () {

        it('Test: Should return error if exhibitionCosts parameter passed to calculateCosts function is a string', function () {
            // Arrange
            let exhibitionCostsParameter = 'test';
            let insuranceCostsParameter = 1500;
            let sponsorParameter = false;
            let errorMessage = 'Invalid Information!';

            // Act

            // Assert
            expect(() => artGallery.calculateCosts(exhibitionCostsParameter, insuranceCostsParameter, sponsorParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if exhibitionCosts parameter passed to calculateCosts function is a number less than zero', function () {
            // Arrange
            let exhibitionCostsParameter = -545;
            let insuranceCostsParameter = 1500;
            let sponsorParameter = false;
            let errorMessage = 'Invalid Information!';

            // Act

            // Assert
            expect(() => artGallery.calculateCosts(exhibitionCostsParameter, insuranceCostsParameter, sponsorParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if insuranceCosts parameter passed to calculateCosts function is a string', function () {
            // Arrange
            let exhibitionCostsParameter = 2500;
            let insuranceCostsParameter = 'test';
            let sponsorParameter = false;
            let errorMessage = 'Invalid Information!';

            // Act

            // Assert
            expect(() => artGallery.calculateCosts(exhibitionCostsParameter, insuranceCostsParameter, sponsorParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if insuranceCosts parameter passed to calculateCosts function is a number less than zero', function () {
            // Arrange
            let exhibitionCostsParameter = 2500;
            let insuranceCostsParameter = -9630;
            let sponsorParameter = false;
            let errorMessage = 'Invalid Information!';

            // Act

            // Assert
            expect(() => artGallery.calculateCosts(exhibitionCostsParameter, insuranceCostsParameter, sponsorParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if sponsor parameter passed to calculateCosts function is a string', function () {
            // Arrange
            let exhibitionCostsParameter = 5845;
            let insuranceCostsParameter = 3456;
            let sponsorParameter = 'test';
            let errorMessage = 'Invalid Information!';

            // Act

            // Assert
            expect(() => artGallery.calculateCosts(exhibitionCostsParameter, insuranceCostsParameter, sponsorParameter)).to.throw(errorMessage);
        });

        it('Test: Should return message if all three paramaters are valid and value of sponsor parameter passed to calculateCosts function is true', function () {
            // Arrange
            let exhibitionCostsParameter = 5500;
            let insuranceCostsParameter = 1550;
            let sponsorParameter = true;
            let totalCost = exhibitionCostsParameter + insuranceCostsParameter;
            let discount = totalCost * 0.10;
            totalCost = totalCost - discount;
            let expected = `Exhibition and insurance costs are ${totalCost}$, reduced by 10% with the help of a donation from your sponsor.`;

            // Act
            let actual = artGallery.calculateCosts(exhibitionCostsParameter, insuranceCostsParameter, sponsorParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if all three paramaters are valid and value of sponsor parameter passed to calculateCosts function is false', function () {
            // Arrange
            let exhibitionCostsParameter = 8534;
            let insuranceCostsParameter = 1799;
            let sponsorParameter = false;
            let totalCost = exhibitionCostsParameter + insuranceCostsParameter;
            let expected = `Exhibition and insurance costs are ${totalCost}$.`;

            // Act
            let actual = artGallery.calculateCosts(exhibitionCostsParameter, insuranceCostsParameter, sponsorParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

    });

    describe('OrganizeExhibits Function Tests', function () {

        it('Test: Should return error if artworksCount parameter passed to organizeExhibits function is a string', function () {
            // Arrange
            let artworksCountParameter = 'test';
            let displaySpacesCountParameter = 15;
            let errorMessage = 'Invalid Information!';

            // Act

            //Assert
            expect(() => artGallery.organizeExhibits(artworksCountParameter, displaySpacesCountParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if artworksCount parameter passed to organizeExhibits function is a number less than zero', function () {
            // Arrange
            let artworksCountParameter = -50;
            let displaySpacesCountParameter = 15;
            let errorMessage = 'Invalid Information!';

            // Act

            //Assert
            expect(() => artGallery.organizeExhibits(artworksCountParameter, displaySpacesCountParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if displaySpacesCount parameter passed to organizeExhibits function is a string', function () {
            // Arrange
            let artworksCountParameter = 150;
            let displaySpacesCountParameter = 'test';
            let errorMessage = 'Invalid Information!';

            // Act

            //Assert
            expect(() => artGallery.organizeExhibits(artworksCountParameter, displaySpacesCountParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if displaySpacesCount parameter passed to organizeExhibits function is a number less than zero', function () {
            // Arrange
            let artworksCountParameter = 150;
            let displaySpacesCountParameter = -82;
            let errorMessage = 'Invalid Information!';

            // Act

            //Assert
            expect(() => artGallery.organizeExhibits(artworksCountParameter, displaySpacesCountParameter)).to.throw(errorMessage);
        });

        it('Test: Should return message if both parameters passed to organizeExhibits function are valid and artworks per space are less than 5', function () {
            // Arrange
            let artworksCountParameter = 12;
            let displaySpacesCountParameter = 4;
            let artworksPerSpace = Math.floor(artworksCountParameter / displaySpacesCountParameter);
            let expected = `There are only ${artworksPerSpace} artworks in each display space, you can add more artworks.`;

            // Act
            let actual = artGallery.organizeExhibits(artworksCountParameter, displaySpacesCountParameter);

            //Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if both parameters passed to organizeExhibits function are valid and artworks per space are bigger than or equal to 5', function () {
            // Arrange
            let artworksCountParameter = 20;
            let displaySpacesCountParameter = 4;
            let artworksPerSpace = Math.floor(artworksCountParameter / displaySpacesCountParameter);
            let expected = `You have ${displaySpacesCountParameter} display spaces with ${artworksPerSpace} artworks in each space.`;

            // Act
            let actual = artGallery.organizeExhibits(artworksCountParameter, displaySpacesCountParameter);

            //Assert
            expect(actual).to.equal(expected);
        });

    });

});
