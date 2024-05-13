namespace DesafioDioEstacionamento.Lib.View;
using DesafioDioEstacionamento.Lib.ViewModel;

public abstract class ViewBase
{
  protected virtual ViewModelBase ViewModel { get; private set; }

  protected ViewBase(ViewModelBase viewModel)
  {
    this.ViewModel = viewModel;
    this.ViewModel.SetView(this);
  }

  public abstract void Notificar(string evento, string? argumento = null);
}
