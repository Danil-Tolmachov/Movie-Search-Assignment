
$(document).ready(function () {

    // Get base path
    const basePath = window.location.protocol + '//' + window.location.hostname + (window.location.port ? ':' + window.location.port : '');

    // Init service
    const movieCategoryService = new MovieCategoryService(basePath);

    // Get movie id
    const path = window.location.pathname;
    const parts = path.split('/');
    let movieId = parts[parts.length - 1];

	$('#confirmCategoryButton').click(function (event) {
		let checkedIds = [];

		// Add checked categories to array
		$("input[type=checkbox]:checked").each(function () {
			checkedIds.push($(this).val())
		});

		// Send request
		movieCategoryService.addCategoryToMovie(movieId, checkedIds)
			.catch(error => {
				console.error('Failed to add category to movie:', error);
				alert('Failed to add category to movie.');
			});
	});
});


class MovieCategoryService
{

	constructor(baseUrl)
	{
		this.baseUrl = baseUrl;
	}

	async addCategoryToMovie(movieId, checkedIds)
	{
		const url = `${this.baseUrl}/api/movie/${movieId}/category/`;

		let formData = new URLSearchParams();
		checkedIds.forEach(id => formData.append('ids', id));

		try
		{
			// Send request
			const response = await fetch(url, {
				method: 'POST',
				body: formData,
            });

			if (!response.ok)
			{
				throw new Error('Failed to add category to movie.');
			}
		}
		catch
		{
			console.error('Error: ', error);
			throw error;
		}
	}

	async removeCategoryFromMovie(movieId, categoryId)
	{
		let url = `${this.baseUrl}/api/movie/${movieId}/category/${categoryId}`;

		try
		{
			// Send request
			const response = await fetch(url, {
				method: 'DELETE',
            });

			if (!response.ok)
			{
				throw new Error('Failed to add category to movie.');
			}
		}
		catch
		{
			console.error('Error: ', error);
			throw error;
		}
	}

	addCategoryElement(categoryId, categoryTitle)
	{
		const element = `<div class="m-1 form-check" id="${categoryId}">
					       <input class="check form-check-input" type="checkbox" value="${categoryId}" checked/>
					       <label class="form-check-label">${categoryTitle}</label>
					     </div>`;

        $('#movieCategoriesContainer').append(element);
    }

    removeCategoryElement(categoryId) {
        $(`#${categoryId}.form-check`).remove();
    }
}
