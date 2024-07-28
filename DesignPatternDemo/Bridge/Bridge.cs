namespace Bridge;


public class Image
{
    public int Width {  get; set; }
    public int Height {  get; set; }
}

public interface IImageRenderer
{
    void Render(Image image);
}

public class LegacyImageRenderer : IImageRenderer
{
    public void Render(Image image)
    {
        Console.WriteLine("Rendering Image via Legacy Approach!!");
    }
}

public class AdvanceImageRenderer : IImageRenderer
{
    public void Render(Image image)
    {
        Console.WriteLine("Rendering Image via Advance Approach!!");
    }
}

//RenderImage is a bridge for rendering image via Legacy or Advance approach. 
public class RenderImage
{
    private readonly IImageRenderer _renderer;
    public RenderImage(IImageRenderer renderer)
    {
        _renderer = renderer;
    }

    public void Render(Image image)
    {
        _renderer.Render(image);
    }
}