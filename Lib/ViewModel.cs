namespace DesafioDioEstacionamento.Lib.ViewModel;

using DesafioDioEstacionamento.Lib.View;

public class ViewModelBase
{
  protected virtual ViewBase? View { get; private set; }

  public void SetView(ViewBase view)
  {
    this.View = view;
  }

  protected void NotificarView(string evento, string? argumento = null)
  {
    if (this.View != null)
    {
      this.View.Notificar(evento, argumento);
    }
  }
}
