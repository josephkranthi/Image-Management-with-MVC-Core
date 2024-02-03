using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud_Images.Models;

namespace Crud_Images.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ImageContext _context;

        public ImagesController(ImageContext context)
        {
            _context = context;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
              return _context.Images != null ? 
                          View(await _context.Images.ToListAsync()) :
                          Problem("Entity set 'ImageContext.Images'  is null.");
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Images == null)
                {
                    return NotFound();
                }

                var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageId == id);

                if (image == null)
                {
                    return NotFound();
                }

                return View(image);
            }
            catch (Exception)
            {
                // Handle the exception here
                ModelState.AddModelError("", "An error occurred while retrieving the image details. Please try again.");

            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,ImageFile")] Image imageModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (Stream stream = imageModel.ImageFile.OpenReadStream())
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            imageModel.ImageData = memoryStream.ToArray();
                            imageModel.ImageName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                            string path = Path.Combine("C:\\Images", $"{imageModel.ImageName}.jpg");
                            System.IO.File.WriteAllBytes(path, imageModel.ImageData);
                        }
                    }

                    _context.Images.Add(imageModel);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", new { id = imageModel.ImageId });



                }
                catch (Exception)
                {
                    // Handle any exception that occurs during the image upload and save process
                    ModelState.AddModelError("ImageFile", "An error occurred while saving the image. Please select correct format.");

                }

            }

            return View(imageModel);
        }


        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,ImageName,ImageFile")] Image imageModel)
        {
            if (id != imageModel.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Construct the paths for the existing and new images
                    string existingImagePath = Path.Combine("C:\\Images", $"{imageModel.ImageName}.jpg");


                    if (imageModel.ImageFile != null && imageModel.ImageFile.Length > 0)
                    {
                        // Delete existing image if it exists
                        if (System.IO.File.Exists(existingImagePath))
                        {
                            System.IO.File.Delete(existingImagePath);
                        }

                        // Save the new image file
                        using (Stream stream = imageModel.ImageFile.OpenReadStream())
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                stream.CopyTo(memoryStream);
                                imageModel.ImageData = memoryStream.ToArray();
                                imageModel.ImageName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                                string path = Path.Combine("C:\\Images", $"{imageModel.ImageName}.jpg");
                                System.IO.File.WriteAllBytes(path, imageModel.ImageData);
                            }
                        }


                    }

                    // Update other properties and save changes
                    _context.Update(imageModel);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError(string.Empty, "The record you attempted to edit was deleted by another user.");
                    return View(imageModel);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the image. Please try again later.");
                    return View(imageModel);
                }
            }

            // Model is not valid, return the view with errors
            return View(imageModel);
        }


        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var image = await _context.Images.FirstOrDefaultAsync(m => m.ImageId == id);

                if (image == null)
                {
                    return NotFound();
                }

                return View(image);
            }
            catch (Exception)
            {
                // Handle the exception here
                ModelState.AddModelError("", "An error occurred while retrieving the image. Please try again.");
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await _context.Images.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }

            try
            {
                // Delete the image file from the folder
                string path = Path.Combine("C:\\Images", $"{imageModel.ImageName}.jpg");
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                _context.Images.Remove(imageModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // Handle error
                ModelState.AddModelError("", "An error occurred while deleting the image.");
                return View(imageModel);
            }
        }

        private bool ImageExists(int id)
        {
          return (_context.Images?.Any(e => e.ImageId == id)).GetValueOrDefault();
        }
    }
}
