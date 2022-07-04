namespace CoronaProject.Models
{
    public class CertificateAPI
    {
        public void Register (WebApplication app)
        {
            app.MapPost("/certificates", async Task<IResult> (HttpRequest request, IVisitorRepository repoVisitor, ICertificateRepository repoCert) =>
            {
                if (!request.HasFormContentType)
                    return Results.BadRequest();

                var form = await request.ReadFormAsync();
                var formFile = form.Files["file"];

                if (formFile is null || formFile.Length == 0)
                    return Results.BadRequest();

                string firstName = form["firstName"];
                string lastName = form["lastName"];
                string strTimeStamp = form["birthDate"];
                string fileName = formFile.FileName;

                if (firstName == null || lastName == null || strTimeStamp == null)
                    return Results.BadRequest();

                long timeStamp = 0;

                if (!Int64.TryParse(strTimeStamp, out timeStamp))
                    return Results.BadRequest();

                DateTime birthDate = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp).Date;

                if(birthDate == new DateTime(1,1,1))
                    return Results.BadRequest();

                Visitor visitor = new Visitor();
                visitor.FirstName = firstName;
                visitor.LastName = lastName;
                visitor.BirthDate = DateOnly.FromDateTime(birthDate).ToDateTime(TimeOnly.Parse("00:00:00"));

                await repoVisitor.InsertVisitorAsync(visitor);
                await repoVisitor.SaveAsync();

                Certificate cert = new Certificate();
                cert.DateAdded = DateTime.Now;

                string fileExt;
                string ext = Path.GetExtension(fileName);
                if (ext.Length > 10) {
                    fileExt = ext.Substring(0, 10);
                }
                else {
                    fileExt = ext;
                }

                cert.FileExtension = fileExt;
                cert.VisitorId = visitor.Id;

                await using var stream = formFile.OpenReadStream();

                var reader = new StreamReader(stream);

                using (MemoryStream ms = new MemoryStream())
                {
                    reader.BaseStream.CopyTo(ms);
                    cert.File = ms.ToArray();
                }

                await repoCert.InsertCertificateAsync(cert);
                await repoCert.SaveAsync();

                return Results.Ok();
            });
        }
    }
}
